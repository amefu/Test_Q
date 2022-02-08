using ApiRest.Data.Entities;
using ApiRest.Infraestructure.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Data.Mapper
{
    public class ProductoProfile:Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductDto>();
            CreateMap<ProductDto, Producto>();


            CreateMap<ProductDtoForCreate, Producto>();
            CreateMap<ProductDtoForUpdate, Producto>();


        }
    }
}
