using BE;
using BE.Personas;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Modelo.Mascotas;
using TP1.Modelo.Personas;

namespace TP1.Modelo
{
    public class DuenioBLL : IPaseador
    {
        private DuenioMPP MPP;
        public double Felicidad { get => 30; }

        public DuenioBLL()
        {
            MPP = new DuenioMPP();
        }
        #region Metodos publicos
        public void AlimentarMascota(double Cantidad, MascotaBE MascotaBe)
        {
            MascotaBLL Mascota = MascotaBLL.ObtenerMascota(MascotaBe);
            Mascota.Comer(Cantidad, MascotaBe);
        }

        public void PasearMascota(MascotaBE MascotaBe, double Distancia)
        {
            MascotaBLL Mascota = MascotaBLL.ObtenerMascota(MascotaBe);
            Mascota.Pasear(Distancia, Felicidad, MascotaBe);
        }

        public void MandarAPasearCon(PaseadorBE PaseadorBe, MascotaBE MascotaBe, int Distancia)
        {
            PaseadorBLL Paseador = new PaseadorBLL();
            Paseador.AgregarMascotaAlPaseo(MascotaBe, PaseadorBe, Distancia);
        }
        #endregion

        #region Consultas
        public bool Alta(DuenioBE Duenio, MascotaBE Mascota)
        {
            return MPP.Guardar(Duenio);
        }
        public List<DuenioBE> ListarDuenios()
        {
            return MPP.ListarTodo();
        }

        public bool ExisteDuenio(string nombre)
        {
            return MPP.ExisteDuenio(nombre);
        }
        #endregion
    }
}
