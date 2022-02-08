using ApiRest.Data.Access;
using ApiRest.Data.Entities;
using ApiRest.Data.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Data.Repository.Service
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IOptions<Settings> settings) : base(settings)
        {
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            try
            {
                using var connection = CreateConnection();
                return (await connection.QueryAsync<Producto>("sp_GetAllProductos")).ToList();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            try
            {
                using var connection = CreateConnection();
                var values = new { idProducto = id };
                return (await connection.QueryFirstOrDefaultAsync<Producto>("sp_GetOneProducto", param:values, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<int> CreateAsync(Producto entity)
        {
            try
            {
                using var connection = CreateConnection();
                //var values = new { 
                //    Nombre = entity.Nombre,
                //    Precio = entity.Precio,
                //    Cantidad = entity.Stock,
                //    Fecha = entity.FechaRegistro
                //};

                var p = new DynamicParameters();
                p.Add("@Nombre", entity.Nombre );
                p.Add("@Precio", entity.Precio);
                p.Add("@Cantidad", entity.Stock);
                p.Add("@Fecha", entity.FechaRegistro);
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("dbo.sp_CreateProducto", p, commandType: CommandType.StoredProcedure);

                return p.Get<int>("@id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Producto entity)
        {
            try
            {
                using var connection = CreateConnection();
                var values = new
                {
                    idProducto = entity.Id,
                    Nombre = entity.Nombre,
                    Precio = entity.Precio,
                    Cantidad = entity.Stock,
                    Fecha = entity.FechaRegistro
                };

                return (await connection.ExecuteAsync("sp_UpdateProducto", param: values, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Producto entity)
        {
            try
            {
                using var connection = CreateConnection();
                var values = new { idProducto = entity.Id };

                return (await connection.ExecuteAsync("sp_DeleteProducto", param: values, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

    }
}
