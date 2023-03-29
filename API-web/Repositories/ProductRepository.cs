using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedCommonModel;
using SharedCommonModel.Admin;
using SharedCommonModel.Product;
using System.Linq;

namespace API_web.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICategory _categoryRepository;

        public ProductRepository(WebDbContext WebDbContext, IMapper mapper, ICategory categoryRepository)
        {
            _context = WebDbContext;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductAdmin>> GetAllProductsAdminAsync()
        {
            var products = await _context.Products
            .Include(p => p.Images)
            .OrderByDescending(p => p.Id)
            .ToListAsync();
            var productAdmin = _mapper.Map<List<Product>, List<ProductAdmin>>(products);
            return productAdmin ?? new List<ProductAdmin>();
        }

        public async Task<ActionResult<ProductAdmin>> GetProductAdminAsync(int id)
        {
            ProductAdmin productAdmin = new ProductAdmin();
            var product = await _context.Products
                .Where(e => e.Id == id)
                .Include(c => c.Images)
                .FirstOrDefaultAsync();
            if (product != null)
            {
                productAdmin = _mapper.Map<Product, ProductAdmin>(product);
            }
            return productAdmin;
        }

        public async Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto)
        {
            ProductPagingDto productPagingDto = new ProductPagingDto();
            List<Product> Listproducts = new List<Product>();
            productPagingDto.totalCount = await _context.Products.CountAsync();
            var products = _context.Products
                .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1))
                .Take(pagingRequestDto.pageSize)
                .Include(c => c.Ratings).Include(c => c.Images)
            .AsQueryable();
            if (pagingRequestDto.sort == 1)
            {
                Listproducts = await products.OrderByDescending(i => i.Id).ToListAsync();

            }
            else
            {
                Listproducts = await products.OrderBy(i => i.Id).ToListAsync();

            }
            var productsDto = _mapper.Map<List<Product>, List<ProductDto>>(Listproducts);
            productPagingDto.products = productsDto;
            return productPagingDto ?? new ProductPagingDto();
        }

        public async Task<ProductPagingDto> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto)
        {
            ProductPagingDto productPagingDto = new ProductPagingDto();
            List<Product> Listproducts = new List<Product>();
            productPagingDto.totalCount = await _context.Products.Include(p => p.CategoryProduct.Where(p => p.CategoryId == pagingRequestDto.id)).CountAsync();
            var products = _context.Products
                .Include(p => p.CategoryProduct.Where(p => p.CategoryId == pagingRequestDto.id))
                .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1))
                .Take(pagingRequestDto.pageSize)
                .Include(c => c.Ratings).Include(c => c.Images)
            .AsQueryable();
            if (pagingRequestDto.sort == 1)
            {
                Listproducts = await products.OrderByDescending(i => i.Id).ToListAsync();

            }
            else
            {
                Listproducts = await products.OrderBy(i => i.Id).ToListAsync();

            }
            var productsDto = _mapper.Map<List<Product>, List<ProductDto>>(Listproducts);
            productPagingDto.products = productsDto;
            return productPagingDto ?? new ProductPagingDto();

        }

        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            ProductDto productDto = new ProductDto();
            var product = await _context.Products
                .Where(p=>p.Id == Id)
                //.Include(c => c.Categories)
                .Include(r => r.Ratings)
                .Include(i => i.Images)
                .Include(c => c.Ratings!.OrderByDescending(r => r.Id)).FirstOrDefaultAsync();
            if (product != null)
            {
                productDto = _mapper.Map<Product, ProductDto>(product);
            }
            return productDto;
        }

        public async Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto)
        {
            ProductPagingDto productPagingDto= new ProductPagingDto();
            if (pagingRequestDto.Search == null)
            {
                productPagingDto = await GetAllProductsPaingAsync(pagingRequestDto);
            }
            else 
            {
                productPagingDto.totalCount = await _context.Products.Where(p => p.ProductName.Contains(pagingRequestDto.Search)).CountAsync();
                var products = await _context.Products
                    .Where(p => p.ProductName.Contains(pagingRequestDto.Search))
                    .Skip(pagingRequestDto.pageSize * (pagingRequestDto.pageIndex - 1))
                    .Take(pagingRequestDto.pageSize)
                    .Include(r => r.Ratings)
                    .Include(i => i.Images)
                    .ToListAsync();

                productPagingDto.products = _mapper.Map<List<Product>,List<ProductDto>>(products);
            }
            return productPagingDto;
            
        }

        //admin
        public async Task<Product> PostProductAsync(ProductAdmin addProduct)
        {
            var product = _mapper.Map<ProductAdmin,Product>(addProduct);


            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return product;
        }


        public string UploadFile(ImageDto file)
        {
            string fileName = file.Url;
            if (file.FormFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/image/product", file.Url);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
            }

            var image = _mapper.Map<ImageDto,Image>(file);
            _context.Images.Add(image);
            _context.SaveChanges();
            return fileName;

        }
        public async Task<bool> PutProductAsync(int Id, ProductAdmin updateProduct)
        {
            if (Id != updateProduct.Id)
            {
                return false;
            }

            var product = _mapper.Map<ProductAdmin, Product>(updateProduct);
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            
        }
    }
}
