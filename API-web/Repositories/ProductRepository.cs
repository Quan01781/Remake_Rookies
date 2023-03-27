using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using AutoMapper;
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

        public Task<List<ProductAdmin>> GetAllProductsAdminAsync()
        {
            throw new NotImplementedException();
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
            productPagingDto.totalCount = await _context.Products.Where(p => p.CategoryId == pagingRequestDto.id).CountAsync();
            var products = _context.Products
                .Where(p => p.CategoryId == pagingRequestDto.id)
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
                .Include(c => c.Categories)
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
    }
}
