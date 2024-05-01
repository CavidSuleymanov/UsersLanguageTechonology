using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Dtos
{
    public class UpdateLanguageTechonolgyDto
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
