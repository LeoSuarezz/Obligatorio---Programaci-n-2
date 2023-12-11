using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Venta> listaVentas = new List<Venta>();
        public static List<Alquiler> listaAlquileres = new List<Alquiler>();


        public static Usuario usuarioLogeado;
        public static void CagarDatosIniciales()
        {
            Usuario usuario = new Usuario();
            usuario.setIdUsuario(1);
            usuario.setUsername("Admin");
            usuario.setNombreUsuario("Admin");
            usuario.setApellidoUsuario("Admin");
            usuario.setPassword("Admin");
            usuario.setVerAlquileres(true);
            usuario.setVerUsuarios(true);
            usuario.setVerVentas(true);
            usuario.setVerClientes(true);
            usuario.setVerVehiculos(true);
            usuario.setVerAlquileres(true);

            listaUsuarios.Add(usuario);

            DateTime anioCamion1 = new DateTime(2020, 1, 1);
            Camion camion1 = new Camion(false, "ABC123", "Volvo", "VNL", 75000, anioCamion1, "Rojo", 60000, 800, "https://www.volvotrucks.mx/-/media/vtna/images/shared/tabbed-carousel/vnl/860.jpg?h=470&w=1016&rev=-1&hash=9030C0EB64B6595E4840F94E60D2E3DF", "https://tadvantagesites-com.cdn-convertus.com/uploads/sites/405/2021/04/VNL-Advanced-Flow-Below-25th-Driver-3-4.jpg", "https://tadvantagesites-com.cdn-convertus.com/uploads/sites/405/2021/04/VNL-Advanced-Flow-Below-25th-Pass-Side.jpg", 15000);
            DateTime anioCamion2 = new DateTime(2019, 1, 1);
            Camion camion2 = new Camion(true, "XYZ789", "Mercedes-Benz", "Actros", 60000, anioCamion2, "Azul", 55000, 750, "https://transportemundial.com.ar/wp-content/uploads/2020/10/actros-especial-edition-2-4.jpg", "https://transportemundial.com.ar/wp-content/uploads/2021/06/mercedes-actros-L-2.jpg", "https://www.transportecarretero.com.uy/media/zoo/images/Mercedes-Benz_Actros_2641_4_5a27d0b30a95cf88204ab3c3ddf0e1a3.jpg", 12000);
            DateTime anioCamion3 = new DateTime(2021, 1, 1);
            Camion camion3 = new Camion(true, "DEF456", "Scania", "R-Series", 80000, anioCamion3, "Blanco", 65000, 900, "https://d1hv7ee95zft1i.cloudfront.net/custom/truck-model-photo/original/60a3b86144a02.jpg", "https://d1hv7ee95zft1i.cloudfront.net/custom/truck-model-photo/original/616d677a0bc9c.jpg", "https://chinamobil.ru/photo/-import/scania/r-series/full/1.jpg", 18000);
            DateTime anioCamion4 = new DateTime(2022, 1, 1);
            Camion camion4 = new Camion(false, "GHI789", "Kenworth", "T680", 70000, anioCamion4, "Negro", 70000, 850, "https://kenworthcolombia.com/wp-content/uploads/destacada-3-scaled-1.jpg", "https://netrinoimages.s3.eu-west-2.amazonaws.com/2010/03/18/24515/427348/kenworth_t680_next_gen_2023_3d_model_c4d_max_obj_fbx_ma_lwo_3ds_3dm_stl_4407480_o.jpg", "https://t21.com.mx/wp-content/uploads/2023/08/kw_T680_100anios_2.jpg", 16000);
            DateTime anioCamion5 = new DateTime(2018, 1, 1);
            Camion camion5 = new Camion(true, "JKL012", "Peterbilt", "579", 50000, anioCamion5, "Verde", 50000, 700, "https://s18391.pcdn.co/wp-content/uploads/2021/02/Peterbilt-Model-579-Next-Generation-Hero-Image.jpg", "https://cdn-ds.com/stock/2024-Peterbilt-579-80andquot-Double-Bunk-Ultraloft-Eagan-MN/seo/ALS1232-1XPBDP9X9RD602129/sz_439151/249104b641a7cf67be01e6284be939d2.jpg", "https://img.ccjdigital.com/files/base/randallreilly/all/image/2022/07/IMG_2779.62d5a41d41a42.png?auto=format%2Ccompress&fit=max&q=70&w=1200", 14000);

            DateTime anioAuto1 = new DateTime(2020, 1, 1);
            Auto auto1 = new Auto(true, "PAA3838", "Toyota", "Camry", 50000, anioAuto1, "Rojo", 25000, 3000, "https://fotos.perfil.com/2023/03/28/toyota-camry-1535572.jpg", "https://acnews.blob.core.windows.net/imggallery/800x600/GAZ_d84ad419208646b497780dbfd0dd920e.jpg", "https://hips.hearstapps.com/hmg-prod/images/c-005-1500x1000-1652713137.jpg?crop=0.893xw:1.00xh;0.0561xw,0&resize=768:*", 5);
            DateTime anioAuto2 = new DateTime(2019, 1, 1);
            Auto auto2 = new Auto(true, "B15489", "Honda", "Civic", 45000, anioAuto2, "Azul", 22000, 2500, "https://cdn.motor1.com/images/mgl/WV6rr/s1/lanzamiento-honda-civic-2017.jpg", "https://hips.hearstapps.com/hmg-prod/images/199431-honda-muestra-su-renovado-civic-type-r-en-el-tokyo-auto-salon-2020-1578660923.jpg?crop=1.00xw:0.753xh;0,0.217xh&resize=2048:*", "https://e00-elmundo.uecdn.es/assets/multimedia/imagenes/2022/12/11/16707779019313.jpg", 4);
            DateTime anioAuto3 = new DateTime(2021, 1, 1);
            Auto auto3 = new Auto(true, "GGH456", "Ford", "Escape", 60000, anioAuto3, "Blanco", 28000, 3000, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi0ZuwoFG3WlJjR2Y-yXlO_HOAdYA9ZHpwW8dNdfx5o7BHmfk1WvA4OEthTK_W8tuKDpM9ULYQpHceRP4sYCxSOMQNEOAVEKC4vgXJrt8jbBchKbBPpNrnz_K6ba18jGQJeYo1EtQlPKFyZyERpYW4i2LtvHv0yMkyprU4J0FgXoFwigMmb_qI6Xbeh/s3192/Copia%20de%202023%20Ford%20Escape%20Plug-In%20Hybrid_Vapor%20Blue_Ford%20Escape%20ST-Line%20Elite_Rapid%20Red_01.jpg", "https://es.ford.com/is/image/content/dam/vdm_ford/live/en_us/ford/nameplate/escape/2024/collections/dm/_F2A0033_V1.tif?croppathe=1_4x3&wid=900", "https://2.bp.blogspot.com/-nfBAz4kg7to/U7RUr4mco5I/AAAAAAAAxx4/AMesaRgfgwI/s1600/ford-escape-uruguay.jpg", 7);
            DateTime anioAuto4 = new DateTime(2022, 1, 1);
            Auto auto4 = new Auto(true, "ASD7892", "Chevrolet", "Malibu", 55000, anioAuto4, "Negro", 26000, 2600, "https://es.chevrolet.com/content/dam/chevrolet/na/us/english/index/vehicles/2024/cars/malibu/01-images/mov/2024-malibu-mov-specialeditions-midnightedition-01.png?imwidth=960", "https://www.sertackemiksiz.com/images/2022/02/12/yeni-chevrolet-malibu-tanitildi-11_large.jpg", "https://2.bp.blogspot.com/-s3V1ay5J9o8/WtYVJEodJ_I/AAAAAAACr_c/1ufjKDErEZ4_LQq_9kY231yyWI6joAyJACLcBGAs/s1600/2019-Chevrolet-Malibu-001.jpg", 5);
            DateTime anioAuto5 = new DateTime(2018, 1, 1);
            Auto auto5 = new Auto(false, "FFG1237", "Nissan", "Altima", 40000, anioAuto5, "Verde", 20000, 2500, "https://www.autosur.mx/resourcefiles/blogsmallimages/nissan-altima-2022-precio.png", "https://hips.hearstapps.com/hmg-prod/images/2023-nissan-altima-105-1654783714.jpg?crop=0.619xw:0.567xh;0.173xw,0.312xh&resize=980:*", "https://media.ed.edmunds-media.com/nissan/altima/2023/oem/2023_nissan_altima_sedan_vc-t-sr_fq_oem_1_1280.jpg", 4);

            DateTime anioMoto1 = new DateTime(2022, 1, 1);
            Moto moto1 = new Moto(false, "M123", "Honda", "CBR600RR", 20000, anioMoto1, "Rojo", 12000, 800, "https://www.bennetts.co.uk/-/media/bikesocial/2021-august-images/honda-cbr600rr-2013-used-review/honda-cbr600rr-2013-review-used-price-spec_thumb.ashx", "https://maintenanceschedule.net/wp-content/uploads/2021/01/2018-Honda-CBR600RR-Black-1024x655.jpg", "https://motoblog.com/wp-content/uploads/2017/06/CBR600RR_2017_03.jpg", 600);
            DateTime anioMoto2 = new DateTime(2021, 1, 1);
            Moto moto2 = new Moto(true, "M456", "Kawasaki", "Ninja 400", 15000, anioMoto2, "Verde", 8000, 800, "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/trimsdb/19361511-0-120005051.jpg", "https://storage.kawasaki.eu/public/kawasaki.eu/en-EU/model/th_23MY_Ninja_400_GY1_STU__1_.jpg", "https://directomotor.com/wp-content/uploads/2022/10/aaa-kawasaki-400.jpg", 400);
            DateTime anioMoto3 = new DateTime(2020, 1, 1);
            Moto moto3 = new Moto(true, "M789", "Yamaha", "YZF-R6", 18000, anioMoto3, "Azul", 10000, 800, "https://todasmoto.com.mx/storage/images/catalog/4780/c824db84-0425-4bac-adac-5f90a4a6bbb6.jpg", "https://www.autonocion.com/wp-content/uploads/2020/11/Yamaha-R6-Race-2021-1.jpg", "https://www.mundomotero.com/wp-content/uploads/2021/05/Yamaha-R6-RACE-2022-7-1200x675-1-1024x576.jpg", 600);
            DateTime anioMoto4 = new DateTime(2019, 1, 1);
            Moto moto4 = new Moto(true, "MABC", "Suzuki", "GSX-R750", 22000, anioMoto4, "Negro", 11000, 800, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_plUF_XvxY4iCyNNCrn2Put3FVHBL1JDfuhEEUApZQ2GgtsteR__VtE4j04QB1QKpDj0&usqp=CAU", "https://suzukicycles.com/-/media/project/cycles/images/products/motorcycles/gsx-r750/2023/gallery/gsx-r750m3_b5n_d_2400x1600.png", "https://suzukimotoscoacalco.com/Assets/ModelosNuevos/img/Modelos/GSX-R750/23/colores/gris.png", 750);
            DateTime anioMoto5 = new DateTime(2018, 1, 1);
            Moto moto5 = new Moto(true, "MXYZ", "Ducati", "Monster 821", 25000, anioMoto5, "Blanco", 13000, 800, "https://ducatimadrid.com/wp-content/uploads/2020/12/moto-ducati-monster.jpg", "https://www.webbikeworld.com/wp-content/uploads/2023/06/2023-Ducati-Monster-4.jpg", "https://images.ctfassets.net/x7j9qwvpvr5s/4JLjM5TumasYv65ya4APZQ/c487cc575f98dfc853762564cadf6ebe/Ducati-Monster-SP-MY23-overview-video-full-01-1330x748.jpg", 821);

            listaVehiculos.Add(camion1);
            listaVehiculos.Add(camion2);
            listaVehiculos.Add(camion3);
            listaVehiculos.Add(camion4);
            listaVehiculos.Add(camion5);
            listaVehiculos.Add(auto1);
            listaVehiculos.Add(auto2);
            listaVehiculos.Add(auto3);
            listaVehiculos.Add(auto4);
            listaVehiculos.Add(auto5);
            listaVehiculos.Add(moto1);
            listaVehiculos.Add(moto2);
            listaVehiculos.Add(moto3);
            listaVehiculos.Add(moto4);
            listaVehiculos.Add(moto5);

            Cliente cliente = new Cliente("45866580", "Juan", "Perez","dr Edye 3456","098765531");

            Cliente cliente2 = new Cliente("45899989", "Javier", "Lopez","dr Edye 5585","098509731");

            Cliente cliente3 = new Cliente("37854682", "Luis", "Gomez","Aigua 3588", "098712313");

            listaClientes.Add(cliente);
            listaClientes.Add(cliente2);
            listaClientes.Add(cliente3);

            DateTime fechaVenta1 = new DateTime(2022, 1, 1);
            Venta venta1 = new Venta(1, 12000, fechaVenta1, "45866580", "M123", "Admin");

            DateTime fechaVenta2 = new DateTime(2023, 5, 1);
            Venta venta2 = new Venta(2, 20000, fechaVenta2, "45899989", "FFG1237", "Admin");

            listaVentas.Add(venta1); 
            listaVentas.Add(venta2);

            DateTime fechaAlq1 = DateTime.Today;
            DateTime fechaAlq2 = DateTime.Today.AddDays(-1);
            Alquiler alquiler1 = new Alquiler(1, 2400, fechaAlq1, 3, false, "37854682", "ABC123", "Admin");
            Alquiler alquiler2 = new Alquiler(2, 8500, fechaAlq2, 10, false, "45899989", "GHI789", "Admin");
            listaAlquileres.Add(alquiler1);
            listaAlquileres.Add(alquiler2);
        }

        public static void GuardarUsuarioLogeado(Usuario usuario)
        {
            usuarioLogeado = usuario;
        }
        public static List<Vehiculo> ObtenerDatosVehiculos()
        {
            return listaVehiculos;
        }
        public static List<Cliente> ObtenerDatosClientes()
        {
            return listaClientes;
        }

    }
}