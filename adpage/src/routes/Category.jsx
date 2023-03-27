import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import Table from 'react-bootstrap/Table';
import React, { useEffect, useState } from 'react';
import {useNavigate} from 'react-router-dom';
import {GetCategory} from '../services/CategoryAPI';
import { AddCategory } from '../services/CategoryAPI';
import { UpdateCategory } from '../services/CategoryAPI';
import {DeleteCategory} from '../services/CategoryAPI';

import '../App.css';


const AllCategory = () => {

  const [categories,setCategories] = useState([]);
  const [query,setQuery] = useState("")
  const [addShow, setAddShow] = useState(false);
  const [updateShow, setUpdateShow] = useState(false);
  const [deleteShow, setDeleteShow] = useState(false);
  const navigate =useNavigate();

  const handleClose = () => {setAddShow(false);setUpdateShow(false);setDeleteShow(false)}
  const handleAddShow = () => setAddShow(true);
  const handleUpdateShow = () => setUpdateShow(true);
  const handleDeleteShow = () => setDeleteShow(true);

  useEffect( ()=>{
  loadCategories()
  } 
  ,[]);
  const loadCategories = async () => {
  const result = await GetCategory();
  console.log(result.data)
  setCategories(result.data);}

  const add_category = async(categoryName, categoryDescription) => {
    const result = await AddCategory(categoryName, categoryDescription);
    console.log(result)
  }

  const update_category = async(categoryName, categoryDescription, categoryID)=>{
    const result = await UpdateCategory(categoryName, categoryDescription, categoryID);
    console.log(result)
  }

  const delete_category = async(categoryID)=>{
    const result = await DeleteCategory(categoryID);
    console.log(result)
  }

  const handleAdd = (e)=>{
    e.preventDefault();
    const name = e.target.name.value;
    const description = e.target.description.value;
    add_category(name, description)
  }

  const handleUpdate = (e)=>{
    e.preventDefault();
    const name = e.target.name.value;
    const description = e.target.description.value;
    const ID = GetCategoryID();
    update_category(name, description, ID)
  }

  const handleDelete = (e)=>{
    const ID = GetCategoryID();
    if(delete_category(ID)){
      alert("delete success")
    }else{alert("failed")}
  }

  function setCategoryID(ID){
    localStorage.setItem("categoryID",ID);
  }

  function GetCategoryID(){
    var x = localStorage.getItem("categoryID");
    return x;
  }


 let table = [];
 if(categories != null){
  table = categories.filter((categories)=>categories.name.toLowerCase().includes(query))
  .map((category) => (
    <tr key={category.id}>
      <td>{category.id}</td>
      <td>{category.name}</td>
      <td>{category.description}</td>
      <td>
        <Button className='edit-button me-2' variant="info"  onClick={()=>{navigate("/detail-category");setCategoryID(category.id);}}>Detail</Button>
        <Button className='edit-button me-2' variant="success"  onClick={()=>{handleUpdateShow();setCategoryID(category.id);}}>Edit</Button>
        <Button className='delete-button' variant="danger" onClick={()=>{handleDeleteShow();setCategoryID(category.id);}}>Delete</Button>
      </td>
    </tr>    

 ));}

 return (
  <div>
    <>
     <Button variant="secondary" onClick={handleAddShow}>
        Add Category
      </Button>

      <input 
        type="text"
        placeholder='Search'
        className='search'
        onChange={(e) => setQuery(e.target.value)}
      />

      <Modal show={addShow} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleAdd}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Category Name</Form.Label>
              <Form.Control
                type="text"
                placeholder="category name"
                autoFocus
                name="name"
                // value={name}
                // onChange={e => setName(e.target.value)}
              />
            </Form.Group>
            <Form.Group
              className="mb-3"
              controlId="exampleForm.ControlTextarea1"
            >
              <Form.Label>Description</Form.Label>
              <Form.Control as="textarea" placeholder="description" name="description" rows={3} />
            </Form.Group>
            <Button type="submit" onClick={handleClose}>
             Add
            </Button>
          </Form>
        </Modal.Body>
        <Modal.Footer>         
        </Modal.Footer>
      </Modal>
    </>

    <>
    <Modal show={updateShow} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Update Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleUpdate}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Category Name</Form.Label>
              <Form.Control
                type="text"
                placeholder="category name"
                autoFocus
                name="name"
                // value={name}
                // onChange={e => setName(e.target.value)}
              />
            </Form.Group>
            <Form.Group
              className="mb-3"
              controlId="exampleForm.ControlTextarea1"
            >
              <Form.Label>Description</Form.Label>
              <Form.Control as="textarea" placeholder="description" name="description" rows={3} />
            </Form.Group>
            <Button type="submit" onClick={handleClose}>
             Update
            </Button>
          </Form>
        </Modal.Body>
        <Modal.Footer>         
        </Modal.Footer>
      </Modal>
    </>

    <>
    <Modal show={deleteShow} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure want to delete this category</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={()=>{handleClose();handleDelete();}}>
            Yes
          </Button>
          <Button variant="primary" onClick={handleClose}>
            No
          </Button>
        </Modal.Footer>
      </Modal>
    </>

  <Table striped hover> 
    <thead>
      <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Description</th>
        <th>Action</th>
      </tr>
    </thead>
    <tbody>
      {table}
    </tbody>
  
  </Table>
  </div>
)
}

export default AllCategory;

