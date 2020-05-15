using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace CopiasSeguras.Cifrado
{
    class zip
    {
        //Comprime un archivo dada una ruta
        public void Comprimir(string path)
        {
            string pathZip = path + ".zip";
            ZipFile.CreateFromDirectory(path, pathZip);
        }

        //Descomprime un archivo dada una ruta
        public void Descomprimir(string pathZip)
        {
            //Elimina la extension de la ruta (.zip)
            string path = pathZip.Remove(pathZip.Length - 4, 4);
            ZipFile.ExtractToDirectory(pathZip, path);
        }
    }
}
