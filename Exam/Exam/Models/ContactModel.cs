using System;
using System.Diagnostics;
using Exam.Entity;
using Exam.Utils;

namespace Exam.Models
{
    public class ContactModel
    {
        public bool Insert(Contact contact)
        {
            try
            {
                using (var stt = SQLiteUtils.GetIntances().Connection.Prepare("INSERT INTO Contact (Name, Phone) VALUES (?, ?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.Phone);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}