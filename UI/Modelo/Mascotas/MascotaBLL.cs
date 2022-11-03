using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Modelo.Excepcion;
using BE.Mascotas;
using BE;
using Mapper;

namespace TP1.Modelo.Mascotas
{
    public abstract class MascotaBLL
    {
        private MascotaMPP MPP;

        public MascotaBLL()
        {
            MPP = new MascotaMPP();
        }

        #region Metodos publicos
        public virtual void Comer(double Cantidad, MascotaBE MascotaBe) {
            GuardarMascota(MascotaBe);
        }

        public virtual void Pasear(double Distancia, double Felicidad, MascotaBE MascotaBe)
        {
            if (!TieneEnergiaSuficiente(Distancia, MascotaBe))
            {
                throw new ExcepcionEnergia();
            }
            else
            {
                MascotaBe.Energia -= ConsumoEnergia(Distancia, MascotaBe);
                MascotaBe.Felicidad += Felicidad;
                GuardarMascota(MascotaBe);
            }
        }

        public virtual bool TieneEnergiaSuficiente(double Distancia, MascotaBE MascotaBe)
        {
            return MascotaBe.Energia >= ConsumoEnergia(Distancia, MascotaBe);
        }

        public virtual double ConsumoEnergia(double Distancia, MascotaBE MascotaBe)
        {
            return 0;
        }

        public static MascotaBLL ObtenerMascota(MascotaBE Mascota)
        {
            if (Mascota is PerroBE)
            {
                return new PerroBLL();
            }
            else if (Mascota is GatoBE)
            {
                return new GatoBLL();
            }
            else
            {
                return new LoroBLL();
            }
        }
        #endregion


        public bool GuardarMascota(MascotaBE Mascota)
        {
            return MPP.Guardar(Mascota);
        }

        public int ObtenerCodigoMascota(MascotaBE Mascota)
        {
            return MPP.ListarObjeto(Mascota).Codigo;
        }

        public List<MascotaBE> ObtenerMascotas()
        {
            return MPP.ListarTodo();
        }

        public bool ExisteMascota(string nombre)
        {
            return MPP.ExisteMascota(nombre);
        }
    }
}