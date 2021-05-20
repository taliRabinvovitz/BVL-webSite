using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BVL.Models;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace BVL.Controllers
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public int children { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
    
    public class HomeController : MyController
    {

        public static string static_lang;
        // GET: Home    
        public ActionResult Index()
        {
            static_lang = this.mylanguage;
            return View("Index");
        }
        //[HttpPost]
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            static_lang = this.mylanguage;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OpenAbout()
        {
            return View("RAbout");
        }
        public ActionResult BeitVaad()
        {
            DateTime now = DateTime.Today;
            List<Avrech> listavrach = Repository.avrechimList.ToList();
            List<Person> listperson=new List<Person>();
            Person person; 

            foreach(var a in listavrach)
            {
                person = new Person();   
                person.age = now.Year - a.date.Year;
                person.children = a.children;    
                person.image = a.image;
                if (static_lang == "en")
                {
                    person.name = Repository.EnglishDetailsList.Find(y => y.Id == a.Id).Ename;
                    person.description = Repository.EnglishDetailsList.Find(y => y.Id == a.Id).Edescription;
                }
                else
                {
                    person.name = Repository.HebroDetailsList.Find(y => y.Id == a.Id).Hname;
                    person.description = Repository.HebroDetailsList.Find(y => y.Id == a.Id).Hdescriptio;
                }
                listperson.Add(person);

            }
           
            return View("BeitVaad", listperson.OrderByDescending(t => t.age));
        }
        public ActionResult VelakachtiEtchem()
        {
            return View("VelakachtiEtchem");
        }
        public ActionResult TorahLeasons()
        {
            return View("TorahLeasons");
        }
        public ActionResult HoldTorah()
        {
            return View("HoldTorah");
            //return View("Contact");
        }
        public ActionResult Audio()
        {
           // ViewBag.subjects = Repository.SubjectsList.ToList();
            List<Audio> lisAudio = Repository.AudioList.ToList();
            List<AudioAndMovieModel> listAudio2 = new List<AudioAndMovieModel>();
            AudioAndMovieModel audio;

            foreach (var a in lisAudio)
            {
                audio = new AudioAndMovieModel();
                audio.kategory = Repository.SubjectsList.Find(s => s.Id == a.kategory).subjectName;
                audio.Subject = a.subject;
                audio.audioOrMovie = a.audio1;
                //if (static_lang == "en")
                //{
                //    person.name = Repository.EnglishDetailsList.Find(y => y.Id == a.Id).Ename;
                //    person.description = Repository.EnglishDetailsList.Find(y => y.Id == a.Id).Edescription;
                //}
                //else
                //{
                //    person.name = Repository.HebroDetailsList.Find(y => y.Id == a.Id).Hname;
                //    person.description = Repository.HebroDetailsList.Find(y => y.Id == a.Id).Hdescriptio;
                //}
                listAudio2.Add(audio);

            }
            return View("Audio", listAudio2);
            
        }

        
        public ActionResult Booklets()
        {
            ViewBag.subjects = Repository.SubjectsList.ToList();
            List<Books> booklist = Repository.BooksList.ToList();
            return View("Booklets", booklist);
        }

        public ActionResult foundbooklets(string subjects)
        {   
            
            List<Subjects> listsubjects = Repository.SubjectsList.ToList();
            int subjectId = listsubjects.Find(a => a.subjectName == subjects).Id;
            List<Books> booklist;
            if(subjects =="הכל")
            booklist= Repository.BooksList.ToList();
            else
            booklist=Repository.BooksList.FindAll(a => a.bookSubject == subjectId).ToList();

            ViewBag.subjects = Repository.SubjectsList.ToList();
            return View("Booklets", booklist);


        }
        
       
        
        public FileResult Download(int FileId)
        {
            int fileId = FileId;
            string name = Repository.BooksList.Find(s => s.Id == fileId).bookName;
            string fileUrl = Repository.BooksList.Find(s => s.Id == fileId).bookUrl;
            byte[] fileBytes = System.IO.File.ReadAllBytes(fileUrl);
            //downloud_try.ext
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }

    

        public ActionResult sent(BVL.Models.EmailFormModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("c.a.shapira@gmail.com");//set the address that will get the mail
                mail.From = new MailAddress("beitvaadlechachamim@gmail.com");//set the address that the mail will sent from it
                mail.Subject = "הודעה מאת אתר הכולל- בית ועד לחכמים";
                string Body = "השולח:  " + _objModelMail.FromName + "   כתובת דוא'ל:  " + _objModelMail.FromEmail + "   מספר טלפון:  " + _objModelMail.Phone + "   תוכן ההודעה:  " + _objModelMail.Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("beitvaadlechachamim@gmail.com", "a5711371!"); // Enter the User name and password of the address that the mail will sent from it  
                smtp.EnableSsl = true;
                smtp.Send(mail);

                ViewBag.Message = string.Format("Your message has been sent successfully, thank you!");


                return View("HoldTorah", _objModelMail);
            }
            else
            {
                return View("HoldTorah", _objModelMail);
            }
        }    
    }
}