import axios from "axios";
const url = "https://localhost:7255/api/product/";
// eslint-disable-next-line import/no-anonymous-default-export
export async function GetProduct() {
  try {
    let result = await axios.get(url+'admin/get-all-products');
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}

export async function AddProduct(productName, productQuantity, productPrice, productCategoryID, productImage, productDescription, color, size){
  try {
    let product={
      name: productName,
      quantity: productQuantity,
      price: productPrice,
      categoryID: productCategoryID,
      image: productImage,
      description: productDescription,
      color: color,
      size: size,
      created_by: null
    };
    let result = await axios.post(url+'add-product', product);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}

export async function AddImage(ImageFile){
  try {
    let result = await axios.post(url+'add-image', ImageFile);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}

export async function UpdateProduct(productID, productName, productQuantity, productPrice, productCategoryID, productImage, productDescription, color, size){
  try {
    let product={
      name: productName,
      quantity: productQuantity,
      price: productPrice,
      categoryID: productCategoryID,
      image: productImage,
      description: productDescription,
      color: color,
      size:size,
      created_by: null
    };
    let result = await axios.put(url+`update-product/${productID}`, product);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }

}


export async function DeleteProduct(productID){
  try {
    let result = await axios.delete(url+`delete-product/${productID}`);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }

}


export async function GetProductByID(productID) {
  try {
    let result = await axios.get(url+`admin/product/${productID}`);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}