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
        public void Comprimir(string path)
        {
            string pathZip = path + ".zip";
            ZipFile.CreateFromDirectory(path, pathZip);
        }

        public void Descomprimir(string pathZip)
        {
            string path = pathZip.Remove(pathZip.Length - 4, 4);
            ZipFile.ExtractToDirectory(pathZip, path);

        }
        
    }
}
