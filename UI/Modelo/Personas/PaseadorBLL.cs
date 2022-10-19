using BE.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Modelo.Excepcion;
using TP1.Modelo.Mascotas;
using TP1.Modelo.Personas;
using BE;
using Mapper;

namespace TP1.Modelo
{
    public class PaseadorBLL : IPaseador
    {
        private PaseadorMPP MPP;

        public double Felicidad { get => 10; }

        public PaseadorBLL ()
        {
            MPP = new PaseadorMPP ();
        }
        #region Metodos publicos
        public void AgregarMascotaAlPaseo(MascotaBE Mascota, PaseadorBE PaseadorBe,int Distancia)
        {
            if (PaseadorBe.Mascotas.Count() < PaseadorBe.CantMaxMascotas)
            {
                PaseadorBe.Mascotas.Add(Mascota);
                PaseoBE Paseo = new PaseoBE ();
                Paseo.Mascota = Mascota;
                Paseo.Paseador = PaseadorBe;
                Paseo.Distancia = Distancia;
                Paseo.Pendiente = true;

                GuardarPaseo(Paseo);
            } else
            {
                throw new ExcepcionLimiteMascotas();
            }
        }
        public void PasearMascota(MascotaBE MascotaBe, double Distancia)
        {
            MascotaBLL Mascota = MascotaBLL.ObtenerMascota(MascotaBe);
            Mascota.Pasear(Distancia, Felicidad, MascotaBe);
        }

        #endregion

        #region Consultas
        public bool Alta(PaseadorBE Paseador)
        {
            return MPP.Guardar(Paseador);
        }
        public List<PaseadorBE> ListarPaseadores()
        {
            return MPP.ListarTodo();
        }

        public bool GuardarPaseo(PaseoBE Paseo)
        {
            return MPP.GuardarPaseo(Paseo);
        }

        public List<PaseoBE> ListarPaseosXEstadoXPaseador(int CodPaseador, int Pendiente)
        {
            return MPP.ListarPaseosXEstadoXPaseador(CodPaseador, Pendiente);
        }

        public int ObtenerDistanciaRecorrida(int CodPaseador)
        {
            return MPP.ObtenerDistanciaRecorrida(CodPaseador);
        }
        #endregion
    }
}
