using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifiUserRecorder.Models
{
    public class RecordRelation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Guid EquipmentID { get; set; }

        public virtual Equipment Equipment { get; set; }

        public Guid WifiRecordID { get; set; }

        public virtual WifiRecord WifiRecord { get; set; }
    }
}
