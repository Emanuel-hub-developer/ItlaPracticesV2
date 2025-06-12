using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystemCRUD.API.Context;
using SalesSystemCRUD.API.Models;

namespace SalesSystemCRUD.API.Controllers
{
    [Route("api/sales/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SalesSystemContext _context;

        public ProductController(SalesSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("obtenerProductos")]
        public IEnumerable<ProductModel> GetProductos()
        {
            return _context.Product.ToList();
        }

      
        [HttpPost]
        [Route("crearProducto")]
        public IActionResult CrearProducto([FromBody] ProductModel nuevoProducto)
        {
            if (nuevoProducto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            var product = new ProductModel
            {
                name = nuevoProducto.name,
                price = nuevoProducto.price,
                stock = nuevoProducto.stock,
                idSupplier = nuevoProducto.idSupplier
            };


            try
            {
                _context.Product.Add(product);


                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
            }

            return Ok(new { success = true, message = "Producto actualizado exitosamente!", result = product });
        }

      
        [HttpPut]
        [Route("actualizarProducto/{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] ProductModel productUpdated)
        {
            if (productUpdated == null)
            {
                return BadRequest("Los datos del producto no pueden ser nulos.");
            }

           
            var existingProduct = _context.Product.Find(id);

            if (existingProduct == null)
            {
                
                return NotFound("producto no encontrado.");
            }

            
            existingProduct.name = productUpdated.name;
            existingProduct.price = productUpdated.price;
            existingProduct.stock = productUpdated.stock;
            existingProduct.idSupplier = productUpdated.idSupplier;
            

            try
            {
                _context.SaveChanges();

            } catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
            }
          


            return Ok(new { success = true, message = "Producto actualizado exitosamente!", result = existingProduct });
        }


        [HttpDelete("eliminarProducto/{id}")]
        public IActionResult EliminarProducto(int id)
        {

            var product = _context.Product.FirstOrDefault(u => u.id == id);

            if (product == null)
            {

                return NotFound(new { success = false, message = "producto no encontrado." });
            }

            
            try
            {
                _context.Product.Remove(product);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
            }

            return Ok(new { success = true, message = "Producto eliminado exitosamente!", result = product });
        }
    }
}
