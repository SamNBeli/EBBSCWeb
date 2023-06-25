using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EBBSCweb.Models
{
	public class Media
	{
		public int Id { get; set; }
		[DisplayName("Nom de la Video")]
		[Required]
		public string Name { get; set; }
        [DisplayName("Position")]
        public int DisplayOrder { get; set; }
		[Required]
        [DisplayName("Liens Youtube")]
        public string Link { get; set; }
	}
}

