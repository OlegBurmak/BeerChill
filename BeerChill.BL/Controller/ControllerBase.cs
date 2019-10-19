using BeerChill.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BeerChill.BL.Controller
{
    abstract public class ControllerBase
    {

        protected void Save(string fileName, object serializeObject)
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, serializeObject);
            }
        }


        protected T Load<T>(string fileName) where T : class
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                T item = null;
                if(fs.Length > 0)
                {
                    item = formatter.Deserialize(fs) as T;
                }
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
        }



    }
}
