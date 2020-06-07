using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifiUserRecorder.Models
{
    public class WifiRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public DateTime DateTime { get; set; }

        public virtual List<RecordRelation> RecordRelations { get; set; }
    }
}
