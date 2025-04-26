// File: Controllers/MahasiswaController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300025;

namespace tpmodul10_103022300025
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static list untuk menyimpan data mahasiswa
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Bagus Hardiyanto", Nim = "103022300025" },
            new Mahasiswa { Nama = "Damai Putra Yudha", Nim = "103022300029" },
            new Mahasiswa { Nama = "Achmad fadjry adlil faqih", Nim = "103022300159" },
            new Mahasiswa { Nama = " Fathan Prayoga Wicaksono", Nim = "10302230070" },
            new Mahasiswa { Nama = "Reiluthfi Shidqi Wienarya", Nim = "103022300112" },
            new Mahasiswa { Nama = " Valentino Favian Bimo", Nim = "103022330059" },
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return mahasiswaList;
        }

        // GET: api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index >= 0 && index < mahasiswaList.Count)
            {
                return mahasiswaList[index];
            }
            return NotFound(new { message = "Mahasiswa tidak ditemukan" });
        }

        // POST: api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa != null && !string.IsNullOrEmpty(mahasiswa.Nama) && !string.IsNullOrEmpty(mahasiswa.Nim))
            {
                mahasiswaList.Add(mahasiswa);
                return Ok(new { message = "Mahasiswa berhasil ditambahkan" });
            }
            return BadRequest(new { message = "Data mahasiswa tidak lengkap" });
        }


        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index >= 0 && index < mahasiswaList.Count)
            {
                var deleted = mahasiswaList[index];
                mahasiswaList.RemoveAt(index);
                return Ok(new { message = "Mahasiswa berhasil dihapus", deleted });
            }
            return NotFound(new { message = "Mahasiswa tidak ditemukan" });
        }
    }
}
