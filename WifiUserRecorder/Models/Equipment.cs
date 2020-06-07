using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifiUserRecorder.Models
{
    public class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Mac { get; set; }

        public string Remark { get; set; }

        public virtual List<RecordRelation> RecordRelations { get; set; }
    }
}
