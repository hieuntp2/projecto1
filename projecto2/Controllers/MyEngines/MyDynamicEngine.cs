using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projecto2.Models;
using System.Threading.Tasks;
namespace projecto2.MyEngines
{
    public class MyDynamicEngine
    {
        ProjectO1Entities db = new ProjectO1Entities();

        public async Task setValue(string key, string value)
        {
            MyDynamicValue info = db.MyDynamicValue.SingleOrDefault(t => t.Key == key);

            // If dont have the key, add new key
            if (info == null)
            {
                info = new MyDynamicValue();
                info.Key = key;
                info.Value = value;
                db.MyDynamicValue.Add(info);
                await db.SaveChangesAsync();
            }
            else
            {
                // set new value for key
                info.Value = value;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task removeValue(string key)
        {
            MyDynamicValue info = db.MyDynamicValue.SingleOrDefault(t => t.Key == key);

            if (info == null)
            {
                return;
            }
            else
            {
                db.MyDynamicValue.Remove(info);
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get value
        /// </summary>
        /// <param name="key"></param>
        /// <returns>null nếu không tồn tại</returns>
        public string getValue(string key)
        {
            MyDynamicValue info = db.MyDynamicValue.SingleOrDefault(t => t.Key == key);

            if (info == null)
            {
                return null;
            }
            else
            {
                return info.Value;
            }
        }

        internal async Task increaseValue(string key)
        {
            MyDynamicValue info = db.MyDynamicValue.SingleOrDefault(t => t.Key == key);

            // If dont have the key, add new key
            if (info == null)
            {
                info = new MyDynamicValue();
                info.Key = key;
                info.Value = "0";
                db.MyDynamicValue.Add(info);
                await db.SaveChangesAsync();
            }
            else
            {
                // set new value for key
                info.Value = (int.Parse(info.Value) + 1).ToString(); ;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
    }
}