using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;  // "dbContect" EF reference property

        // Constructor Method is a method that has the same name as the class
        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            // CREATE operation
            // Comment out after creation
            
            Company MyCompany = new Company();
            MyCompany.Id = "MCOB";
            MyCompany.name = "ISM";
            MyCompany.date = "ISM";
            MyCompany.isEnabled = true;
            MyCompany.type = "ISM";
            MyCompany.iexId = "ISM";

            Quote MyCompanyQuote1 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote1.date = "11-23-2018";
            MyCompanyQuote1.open = 46.13F;
            MyCompanyQuote1.high = 47.18F;
            MyCompanyQuote1.low = 44.67F;
            MyCompanyQuote1.close = 47.01F;
            MyCompanyQuote1.volume = 37654000;
            MyCompanyQuote1.unadjustedVolume = 37654000;
            MyCompanyQuote1.change = 1.43F;
            MyCompanyQuote1.changePercent = 0.03F;
            MyCompanyQuote1.vwap = 9.76F;
            MyCompanyQuote1.label = "Nov 23";
            MyCompanyQuote1.changeOverTime = 0.56F;
            MyCompanyQuote1.Company = MyCompany;

            Quote MyCompanyQuote2 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote2.date = "11-23-2018";
            MyCompanyQuote2.open = 46.13F;
            MyCompanyQuote2.high = 47.18F;
            MyCompanyQuote2.low = 44.67F;
            MyCompanyQuote2.close = 47.01F;
            MyCompanyQuote2.volume = 37654000;
            MyCompanyQuote2.unadjustedVolume = 37654000;
            MyCompanyQuote2.change = 1.43F;
            MyCompanyQuote2.changePercent = 0.03F;
            MyCompanyQuote2.vwap = 9.76F;
            MyCompanyQuote2.label = "Nov 23";
            MyCompanyQuote2.changeOverTime = 0.56F;
            MyCompanyQuote2.Company = MyCompany;

            Course MyCourse1 = new Course();
            MyCourse1.Id = "ISM6225";
            MyCourse1.Name = "Distributed Information Systems";

            Course MyCourse2 = new Course();
            MyCourse2.Id = "MAN6147";
            MyCourse2.Name = "Leadership & Management Concepts";

            Student Student1 = new Student();
            Student1.Id = "1234";
            Student1.Name = "Erich McCartney";

            Enrollment MyEnrollment1 = new Enrollment();
            MyEnrollment1.Id = "370U21.59021";
            MyEnrollment1.course = MyCourse1;
            MyEnrollment1.student = Student1;
            MyEnrollment1.grade = "A";

            Enrollment MyEnrollment2 = new Enrollment();
            MyEnrollment2.Id = "370U21.56382";
            MyEnrollment2.course = MyCourse2;
            MyEnrollment2.student = Student1;
            MyEnrollment2.grade = "A";

            // happening in memory, EF optimizing relationship to database
            dbContext.Companies.Add(MyCompany);
            dbContext.Quotes.Add(MyCompanyQuote1);
            dbContext.Quotes.Add(MyCompanyQuote2);
            dbContext.Courses.Add(MyCourse1);
            dbContext.Courses.Add(MyCourse2);
            dbContext.Students.Add(Student1);
            dbContext.Enrollments.Add(MyEnrollment1);
            dbContext.Enrollments.Add(MyEnrollment2);

            dbContext.SaveChanges();

            

            // READ operation
            Student StudentRead1 = dbContext.Students
                                    .Where(s => s.Id == "1234")
                                    .First();

            Course CourseRead1 = dbContext.Courses
                                    .Where(c => c.Id.Contains("ISM"))
                                    .First();

            Enrollment EnrollmentRead1 = dbContext.Enrollments
                                            .Include(c => c.student)
                                            .Where(e => e.student == Student1)
                                            .First();                                          
            
           
            /*
            Company CompanyRead1 = dbContext.Companies //or .CreateDbCommand to use pure SQL syntax
                                    .Where(c => c.Id == "MCOB")
                                    .Where(c => c.Quotes.Count > 20 &&
                                                    c.name.Contains("MCOB")) //anonymous function
                                    .First();
            
            
            int CompanyQuotesSum = dbContext.Companies
                                            .Where(c => c.name == "MCOB")
                                            .First()
                                            .Quotes
                                            .Select(q => q.high)
                                            .Aggregate()
            

            Company CompanyRead2 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.Id == "MCOB")
                                    .First();
            */
            
            /*
            // UPDATE operation
            CompanyRead1.iexId = "MCOB";
            dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            //dbContext.Companies.Remove(CompanyRead1);
            //await dbContext.SaveChangesAsync();
            */
            return View();
            
        }

        public ViewResult LINQOperations()
        {
            Student StudentRead1 = dbContext.Students
                                    .Where(s => s.Id == "1234")
                                    .First();

            Course CourseRead1 = dbContext.Courses
                                    .Where(c => c.Id.Contains("ISM"))
                                    .First();

            Enrollment EnrollmentRead1 = dbContext.Enrollments
                                            .Include(c => c.student)
                                            .Where(e => e.student == StudentRead1)
                                            .First();          
            /*
            Company CompanyRead1 = dbContext.Companies
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Company CompanyRead2 = dbContext.Companies
                                            .Include(c => c.Quotes)
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Quote Quote1 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.Id == "MCOB")
                                    .FirstOrDefault()
                                    .Quotes
                                    .FirstOrDefault();
            */

            return View();
        }

    }
}