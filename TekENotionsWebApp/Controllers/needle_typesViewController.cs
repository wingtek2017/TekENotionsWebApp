using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    public class NeedleSize
    {
        public int Metric { get; set; }
        public int ID { get; set; }
        public string US { get; set; }
        public string Hook { get; set; }
    }

    public class Needle_typesViewController : Controller
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: needle_typesView

        public void GetPattern(string patternID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.ravelry.com/patterns/" + patternID + ".json");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                JavaScriptSerializer js = new JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                needle_types type = new needle_types();


                foreach (var o in obj["pattern"])
                {
                   
                    string testing = o["notes"];


                }

            }
        }
        public ActionResult Index()
        {
            GetPatternTypes();

            return View(db.needle_types.ToList());
        }

        // GET: needle_typesView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_types needle_types = db.needle_types.Find(id);
            if (needle_types == null)
            {
                return HttpNotFound();
            }
            return View(needle_types);
        }

        // GET: needle_typesView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: needle_typesView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type_name,needle_size_id,description,name,length,metric_name")] needle_types needle_types)
        {
            if (ModelState.IsValid)
            {
                db.needle_types.Add(needle_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(needle_types);
        }

        // GET: needle_typesView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_types needle_types = db.needle_types.Find(id);
            if (needle_types == null)
            {
                return HttpNotFound();
            }
            return View(needle_types);
        }

        // POST: needle_typesView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_name,needle_size_id,description,name,length,metric_name")] needle_types needle_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(needle_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(needle_types);
        }

        // GET: needle_typesView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_types needle_types = db.needle_types.Find(id);
            if (needle_types == null)
            {
                return HttpNotFound();
            }
            return View(needle_types);
        }

        // POST: needle_typesView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            needle_types needle_types = db.needle_types.Find(id);
            db.needle_types.Remove(needle_types);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GetNeedlesFromPatternId()
        {

            string url = "https://api.ravelry.com/patterns/";
            string json = ".json";
            var patternList = from a in db.patterns select a;

            foreach (pattern p in patternList.ToList<pattern>())
            {
                var newUrl = url + p.id + json;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                    pattern _pattern = new pattern();
                    var needle_sizes = obj["pattern"]["pattern_needle_sizes"];
                    {
                        if (needle_sizes != null)
                        {
                            //want to get all potential needles
                            foreach(var needle_size in needle_sizes)
                            {
                                var _pattern_needle_size = new pattern_needle_size();
                                _pattern_needle_size.pattern_id = p.id;
                                _pattern_needle_size.needle_size_id = needle_size["id"];

                                var needle_id = needle_size["id"];

                                if (db.pattern_needle_size.Any(x => x.needle_size_id == _pattern_needle_size.needle_size_id && x.pattern_id == p.id  ))
                                {

                                }
                                else
                                {
                                    db.pattern_needle_size.Add(_pattern_needle_size);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        string test = ex.Message;
                                        throw;
                                    }
                                }
                                
                            }
                        }
                    }

                }

              }
         }

            private void GetPatterns()
        {
            string url = "https://api.ravelry.com/patterns/search.json?page=";

            for (int i = 1; i < 10000; i++)
            {
                var newUrl = url + i;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                    pattern _pattern = new pattern();


                    foreach (var o in obj["patterns"])
                    {
                        _pattern = new pattern();

                        _pattern.id = o["id"];


                        if (db.patterns.Any(x => x.id == _pattern.id))
                        {

                        }
                        else
                        {


                            _pattern.name = o["name"];
                            _pattern.free = o["free"];
                            if (o["permalink"] != null)
                                _pattern.permalink = o["permalink"];

                            //photo
                            if (o["first_photo"] != null)
                            {
                                photo _photo = new photo();
                                _pattern.first_photo_id = o["first_photo"]["id"];
                                int photoId = o["first_photo"]["id"];
                                if (db.photos.Any(x => x.id == photoId))
                                {

                                }
                                else
                                {
                                    _photo.id = o["first_photo"]["id"];
                                    if (o["first_photo"]["caption"] != null)
                                        _photo.caption = o["first_photo"]["caption"];
                                    if (o["first_photo"]["caption_html"] != null)
                                        _photo.caption_html = o["first_photo"]["caption_html"];
                                    if (o["first_photo"]["copyright_holder"] != null)
                                        _photo.copyright_holder = o["first_photo"]["copyright_holder"];
                                    if (o["first_photo"]["medium2_url"] != null)
                                        _photo.medium2_url = o["first_photo"]["medium2_url"];
                                    if (o["first_photo"]["small2_url"] != null)
                                        _photo.small2_url = o["first_photo"]["small2_url"];
                                    if (o["first_photo"]["small_url"] != null)
                                        _photo.small_url = o["first_photo"]["small_url"];
                                    if (o["first_photo"]["sort_order"] != null)
                                        _photo.sort_order = o["first_photo"]["sort_order"];
                                    if (o["first_photo"]["square_url"] != null)
                                        _photo.square_url = o["first_photo"]["square_url"];
                                    if (o["first_photo"]["thumbnail_url"] != null)
                                        _photo.thumbnail_url = o["first_photo"]["thumbnail_url"];
                                    if (o["first_photo"]["x_offset"] != null)
                                        _photo.x_offset = o["first_photo"]["x_offset"];
                                    if (o["first_photo"]["y_offset"] != null)
                                        _photo.y_offset = o["first_photo"]["y_offset"];
                                    db.photos.Add(_photo);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        string test = ex.Message;
                                        throw;
                                    }
                                }

                            }

                            //designer
                            if (o["designer"] != null)
                            {
                                int id = o["designer"]["id"];

                                if (db.pattern_author.Any(x => x.id == id))
                                {

                                }
                                else
                                {
                                    pattern_author designer = new pattern_author();
                                    _pattern.designer_id = o["designer"]["id"];
                                    designer.id = o["designer"]["id"];
                                    if (o["designer"]["name"] != null)
                                        designer.name = o["designer"]["name"];
                                    if (o["designer"]["permalink"] != null)
                                        designer.permalink = o["designer"]["permalink"];
                                    designer.favorites_count = o["designer"]["favorites_count"];
                                    designer.patterns_count = o["designer"]["patterns_count"];
                                    db.pattern_author.Add(designer);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        string test = ex.Message;
                                        throw;
                                    }
                                }

                            }

                            _pattern.pattern_author_id = o["pattern_author"]["id"];
                            //pattern_author
                            if (o["pattern_author"] != null)
                            {
                                int id = o["pattern_author"]["id"];
                                if (db.pattern_author.Any(x => x.id == id))
                                {

                                }
                                else
                                {
                                    pattern_author _pattern_author = new pattern_author();
                                    _pattern.designer_id = o["pattern_author"]["id"];
                                    _pattern_author.id = o["pattern_author"]["id"];
                                    if (o["pattern_author"]["name"] != null)
                                        _pattern_author.name = o["pattern_author"]["name"];
                                    if (o["pattern_author"]["permalink"] != null)
                                        _pattern_author.name = o["pattern_author"]["permalink"];
                                    _pattern_author.favorites_count = o["pattern_author"]["favorites_count"];
                                    _pattern_author.patterns_count = o["pattern_author"]["patterns_count"];

                                    db.pattern_author.Add(_pattern_author);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        string test = ex.Message;
                                        throw;
                                    }
                                }
                            }

                            db.patterns.Add(_pattern);
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (DbUpdateException ex)
                            {
                                string test = ex.Message;
                                throw;
                            }
                        }
                    }
                }
            }

            /*
          //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.ravelry.com/needles/sizes.json");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.ravelry.com/needles/types.json");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                JavaScriptSerializer js = new JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                needle_types type = new needle_types();


                foreach (var o in obj["needle_types"])
                {
                    type = new needle_types();
                    type.description = o["description"];
                    type.needle_size_id = o["needle_size_id"];
                    type.id = o["id"];
                    type.type_name = o["type_name"];
                    type.name = o["name"];
                    type.length = o["length"];
                    type.metric_name = o["metric_name"];

                    db.needle_types.Add(type);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        throw;
                    }

                }



            }

            */
            /*

             using (Stream responseStream = response.GetResponseStream())
             {
                 StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                 JavaScriptSerializer js = new JavaScriptSerializer();
                 var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                 needle_sizes size = new needle_sizes();


                 foreach(var o in obj["needle_sizes"])
                 {
                     size = new needle_sizes();
                     size.metric = o["metric"];
                     size.us = o["us"];
                     size.id = o["id"];
                     size.hook = o["hook"];

                     db.needle_sizes.Add(size);
                     try
                     {
                         db.SaveChanges();
                     }
                     catch (DbUpdateException)
                     {
                         throw;
                     }

                 }



             }

     */
        }

        private void GetYarns()
        {
            string url = "https://api.ravelry.com/yarns/search.json?page=";

            for (int i = 1; i < 10000; i++)
            {
                var newUrl = url + i;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                    yarn _yarn = new yarn();


                    foreach (var o in obj["yarns"])
                    {
                        _yarn = new yarn();

                        _yarn.id = o["id"];


                        if (db.yarns.Any(x => x.id == _yarn.id))
                        {

                        }
                        else
                        {
                            if (o["yarn_company_name"] != null)
                                _yarn.yarn_company_name = o["yarn_company_name"];
                            if(o["rating_total"] != null)
                                _yarn.rating_total = o["rating_total"];
                            if(o["max_gauge"] != null)
                                _yarn.max_gauge = o["max_gauge"];
                            if (o["permalink"] != null)
                                _yarn.permalink = o["permalink"];
                            if (o["min_gauge"] != null)
                                _yarn.min_gauge = o["min_gauge"];
                            if (o["grams"] != null)
                                _yarn.grams = o["grams"];
                            if (o["discontinued"] != null)
                                _yarn.discontinued = o["discontinued"];
                            if (o["gauge_divisor"] != null)
                                _yarn.gauge_divisor = o["gauge_divisor"];
                            if (o["texture"] != null)
                                _yarn.texture = o["texture"];
                            if (o["name"] != null)
                                _yarn.name = o["name"];
                            if (o["rating_average"] != null)
                                _yarn.rating_average = o["rating_average"];
                            if (o["machine_washable"] != null)
                                _yarn.machine_washable = o["machine_washable"];
                            if (o["yardage"] != null)
                                _yarn.yardage = o["yardage"];
                           

                            //photo
                            if (o["first_photo"] != null)
                            {
                                photo _photo = new photo();
                                _yarn.first_photo_id = o["first_photo"]["id"];
                                int photoId = o["first_photo"]["id"];
                                if (db.photos.Any(x => x.id == photoId))
                                {

                                }
                                else
                                {
                                    _photo.id = photoId;
                                    _yarn.first_photo_id = o["first_photo"]["id"];
                                    if (o["first_photo"]["caption"] != null)
                                        _photo.caption = o["first_photo"]["caption"];
                                    if (o["first_photo"]["caption_html"] != null)
                                        _photo.caption_html = o["first_photo"]["caption_html"];
                                    if (o["first_photo"]["copyright_holder"] != null)
                                        _photo.copyright_holder = o["first_photo"]["copyright_holder"];
                                    if (o["first_photo"]["medium2_url"] != null)
                                        _photo.medium2_url = o["first_photo"]["medium2_url"];
                                    if (o["first_photo"]["small2_url"] != null)
                                        _photo.small2_url = o["first_photo"]["small2_url"];
                                    if (o["first_photo"]["small_url"] != null)
                                        _photo.small_url = o["first_photo"]["small_url"];
                                    if (o["first_photo"]["sort_order"] != null)
                                        _photo.sort_order = o["first_photo"]["sort_order"];
                                    if (o["first_photo"]["square_url"] != null)
                                        _photo.square_url = o["first_photo"]["square_url"];
                                    if (o["first_photo"]["thumbnail_url"] != null)
                                        _photo.thumbnail_url = o["first_photo"]["thumbnail_url"];
                                    if (o["first_photo"]["x_offset"] != null)
                                        _photo.x_offset = o["first_photo"]["x_offset"];
                                    if (o["first_photo"]["y_offset"] != null)
                                        _photo.y_offset = o["first_photo"]["y_offset"];
                                    db.photos.Add(_photo);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        string test = ex.Message;
                                        throw;
                                    }
                                }

                            }

                            try
                            {
                                if (o["yarn_weight"] != null)
                                {
                                    int id = o["yarn_weight"]["id"];
                                    _yarn.yarn_weight_id = id;
                                    if (db.yarn_weight.Any(x => x.id == id))
                                    {

                                    }
                                    else
                                    {
                                        yarn_weight yarnWeight = new yarn_weight();
                                        _yarn.yarn_weight_id = id;
                                        yarnWeight.id = o["yarn_weight"]["id"];
                                        if (o["yarn_weight"]["ply"] != null)
                                            yarnWeight.ply = o["yarn_weight"]["ply"];
                                        if (o["yarn_weight"]["crochet_gauge"] != null)
                                            yarnWeight.crochet_gauge = o["yarn_weight"]["crochet_gauge"];
                                        if (o["yarn_weight"]["wpi"] != null)
                                            yarnWeight.wpi = o["yarn_weight"]["wpi"];
                                        if (o["yarn_weight"]["name"] != null)
                                            yarnWeight.name = o["yarn_weight"]["name"];
                                        if (o["yarn_weight"]["knit_gauge"] != null)
                                            yarnWeight.name = o["yarn_weight"]["knit_gauge"];


                                        db.yarn_weight.Add(yarnWeight);
                                        try
                                        {
                                            db.SaveChanges();
                                        }
                                        catch (DbUpdateException ex)
                                        {
                                            string test = ex.Message;
                                            throw;
                                        }
                                    }

                                }
                            }
                            catch(Exception ex)
                            {
                                var test = ex.Message;
                            }
                            //designer
                           

                           

                            db.yarns.Add(_yarn);
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (DbUpdateException ex)
                            {
                                string test = ex.Message;
                                throw;
                            }
                        }
                    }
                }
            }

            /*
          //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.ravelry.com/needles/sizes.json");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.ravelry.com/needles/types.json");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                JavaScriptSerializer js = new JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                needle_types type = new needle_types();


                foreach (var o in obj["needle_types"])
                {
                    type = new needle_types();
                    type.description = o["description"];
                    type.needle_size_id = o["needle_size_id"];
                    type.id = o["id"];
                    type.type_name = o["type_name"];
                    type.name = o["name"];
                    type.length = o["length"];
                    type.metric_name = o["metric_name"];

                    db.needle_types.Add(type);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        throw;
                    }

                }



            }

            */
            /*

             using (Stream responseStream = response.GetResponseStream())
             {
                 StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                 JavaScriptSerializer js = new JavaScriptSerializer();
                 var obj = js.Deserialize<dynamic>(reader.ReadToEnd());

                 needle_sizes size = new needle_sizes();


                 foreach(var o in obj["needle_sizes"])
                 {
                     size = new needle_sizes();
                     size.metric = o["metric"];
                     size.us = o["us"];
                     size.id = o["id"];
                     size.hook = o["hook"];

                     db.needle_sizes.Add(size);
                     try
                     {
                         db.SaveChanges();
                     }
                     catch (DbUpdateException)
                     {
                         throw;
                     }

                 }



             }

     */
        }

        private void GetPatternTypes()
        {
            string url = "https://api.ravelry.com/pattern_categories/list.json";

            for (int i = 1; i < 10000; i++)
            {
               
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("A557BB258D37DE039AC3:VVaoS9R2Lvwhy_ToXF9AtyyBN9czTkD8IyTK7bvU"));

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());





                }
                        }
                   
        }
    }


}
