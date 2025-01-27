using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;



public struct Archivo
{
    public string nombreArchivo;
    public int estado;
    public int cant_uA;
    public ArrayList TablaDirecciones;
}

namespace FireSim
{
    public class FileSim
    {
        private string organizacionFisica;
        private string algoritmoBusqueda;
        private string adminEspacio;
        private int metocoAcceso;
        private ArrayList TablaOperaciones;
        private Dispositivo disp;
        private int ContadorOp;
        private ArrayList TablaArchivos;
        private Dictionary<string, Indicadores> indicadorArchivo; //para cada 
                                                                  //string NombreArchivo se tiene asociado una estructura Indicadores que almacena los resultados de la simulacion
        
        public FileSim()
        {
            // En el constructor de FileSim se crearia el array de operaciones (vacio)
            this.TablaOperaciones = new ArrayList();
            this.TablaArchivos = new ArrayList();
            this.SetContadorOp(0);
        }

        //En la pantalla de config el simulador obtendra todos los siguientes parametros
        //para crear el disp
        public void cargaConfig(int tProc, string orgFisica, string algBusqueda, string admEspacio, int metAcceso, 
                                int tLectura, int tEscritura, int tSeek, int tamBloques, int tamDispositivo)
        {

            //setters parametros fileSim
            SetOrganizacionFisica(orgFisica);
            SetAlgoritmoBusqueda(algBusqueda);
            SetAdminEspacio(admEspacio);
            SetMetocoAcceso(metAcceso);

            //Se crea el dispositivo 
            this.disp = new Dispositivo(tLectura, tEscritura, tSeek, tamBloques, tamDispositivo, tProc);

        }

        public void CargarOperaciones(string ruta)
        {
            // Lee el archivo, se cargan las operaciones en this.TablaOperaciones y se ordena por tArribo
            // Se genera el mapa
            
            try
            {
                // El metodo ReadAllLines de File, cierra el archivo automaticamente.
                string[] lineas = File.ReadAllLines(ruta);
            
                Operacion opAux = new Operacion();
                foreach (var linea in lineas)
                {
                    var valores = linea.Split(";");
                    opAux.NombreArchivo = valores[0];
                    opAux.IdOperacion = char.Parse(valores[1]);
                    opAux.NumProceso = Int32.Parse(valores[2]);
                    opAux.Tarribo = Int32.Parse(valores[3]);
                    opAux.Offset = Int32.Parse(valores[4]);
                    opAux.Estado = 0;
                    TablaOperaciones.Add(opAux);
                }

                TablaOperaciones.Sort(new ComparaOp());
                
                /*  Bloque solo de testeo de metodo Sort*/
                foreach(Operacion op in TablaOperaciones)
                {
                    Console.WriteLine(op.NombreArchivo + " " + op.IdOperacion + " " + op.NumProceso + " " +
                        op.Tarribo + " " + op.Offset + " " + op.Estado);
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

        }

        public int CantBloques()
        {
            return this.disp.GetCantBloques();
        }

        // EstadoBloque devuelve un float de 0 a 1 indicando el estado del bloque
        // si es 0 el bloque esta vacio, si es 1 esta lleno, lo demas es el porcentaje de ocupacion del bloque
        public float EstadoBloque(int bloque) //que hace este metodo?
        {
            return disp.estadoBloque(bloque);
        }

        public void SimularSiguienteOp()
        {
            Operacion nextOp = ((Operacion)TablaOperaciones[GetContadorOp()]);
            //case --> CREATE(n) / WRITE(w) / READ(r) / OPEN(o) / CLOSE(c) / DELETE(d)
            switch (Char.ToUpper(nextOp.IdOperacion))
            {
                case 'N':
                    {
                        Create(nextOp.NumProceso, nextOp.Offset, nextOp.CantidadUA, nextOp.NombreArchivo);
                        break;
                    }
                case 'D':
                    {
                        Delete();
                        break;
                    }
                case 'O':
                    {
                        Open();
                        break;
                    }
                case 'C':
                    {
                        Close();
                        break;
                    }
                case 'R':
                    {
                        Read();
                        break;
                    }
                case 'W':
                    {
                        Write();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Operacion Incorrecta, se descarta");
                        break;
                    }
            }
            SetContadorOp(GetContadorOp() + 1);
        }

        public void Create(int idProc, int offset, int cant_uA, string name)
        {
            Archivo archivo;
            archivo.nombreArchivo = name;
            archivo.cant_uA = cant_uA;
            archivo.estado = -1; // Se creo pero no esta abierto
            archivo.TablaDirecciones = new ArrayList();
            disp.GetLibres(cant_uA, GetOrganizacionFisica(), archivo.TablaDirecciones);
        }

        public void Write()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Read()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Open()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /**
         * Getters y Setters
        **/

        public int GetCantidadOp()
        {
            return this.TablaOperaciones.Count;
        }

        public int GetContadorOp()
        {
            return this.ContadorOp;
        }

        public void SetContadorOp(int value)
        {
            ContadorOp = value;
        }

        public Operacion GetOperacion() //devuelve la operacion actual?
        {
            return (Operacion)this.TablaOperaciones[this.ContadorOp];
        }

        //Una vez cargada la configuracion vamos a permitir cambiarla, porq esto significa que
        //vamos a tener que modificar al dispositivo tambien (no solo en el constructor de FileSim)!!!
        // No entendi (Fede)
        public string GetOrganizacionFisica()
        {
            return organizacionFisica;
        }

        public void SetOrganizacionFisica(string value)
        {
            organizacionFisica = value;
        }

        public string GetAlgoritmoBusqueda()
        {
            return algoritmoBusqueda;
        }

        public void SetAlgoritmoBusqueda(string value)
        {
            algoritmoBusqueda = value;
        }

        public string GetAdminEspacio()
        {
            return adminEspacio;
        }

        public void SetAdminEspacio(string value)
        {
            adminEspacio = value;
        }

        public int GetMetocoAcceso()
        {
            return metocoAcceso;
        }

        public void SetMetocoAcceso(int value)
        {
            metocoAcceso = value;
        }
    }
}


public class ComparaOp : IComparer
{
    public int Compare(object x, object y)
    {
        if (((Operacion)y).Tarribo > ((Operacion)x).Tarribo)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
