using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesSystemCRUD.API.Context;
using SalesSystemCRUD.API.Models;

namespace SalesSystemCRUD.API.Controllers
{
    [Route("api/sales/")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SalesSystemContext _context;

        public SupplierController(SalesSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("obtenerProveedores")]
        public IEnumerable<SupplierModel> GetProveedores()
        {
            return _context.Supplier.ToList();
        }


        [HttpPost]
        [Route("crearProveedor")]
        public IActionResult CrearProveedor([FromBody] SupplierModel newSupplier)
        {
            if (newSupplier == null)
            {
                return BadRequest("El proveedor no puede ser nulo.");
            }


            var supplier = new SupplierModel
            {
                name = newSupplier.name,
                contact = newSupplier.contact,

            };

            try
            {
                _context.Supplier.Add(supplier);


                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el proveedor:{ex.Message}");
            }



            return Ok(new { success = true, message = "Proveedor creado exitosamente!", result = supplier });
        }


        [HttpPut]
        [Route("actualizarProveedor/{id}")]
        public IActionResult ActualizarProveedor(int id, [FromBody] SupplierModel supplierUpdated)
        {
            if (supplierUpdated == null)
            {
                return BadRequest("Los datos del proveedor no pueden ser nulos.");
            }


            var existingSupplier = _context.Supplier.Find(id);

            if (existingSupplier == null)
            {

                return NotFound("proveedor no encontrado.");
            }


            existingSupplier.name = supplierUpdated.name;
            existingSupplier.contact = supplierUpdated.contact;


            try
            {
                _context.SaveChanges();

            } catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el proveedor:{ex.Message}");
            }

            return Ok(new { success = true, message = "Proveedor actualizado exitosamente!", result = existingSupplier });
        }


        [HttpDelete("eliminarProveedor/{id}")]
        public IActionResult EliminarProveedor(int id)
        {

            var supplier = _context.Supplier.FirstOrDefault(u => u.id == id);

            if (supplier == null)
            {

                return NotFound(new { success = false, message = "proveedor no encontrado." });
            }

            try
            {
                _context.Supplier.Remove(supplier);

                _context.SaveChanges();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el proveedor:{ex.Message}");
            }
            

            return Ok(new { success = true, message = "Proveedor eliminado exitosamente!", result = supplier });
        }


    }
}
