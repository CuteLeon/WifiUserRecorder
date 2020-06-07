using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WifiUserRecorder.Models;

namespace WifiUserRecorderTests.DataAccess.Tests
{
    [TestClass()]
    public class RecordDBContextTests
    {
        [TestMethod()]
        public void RecordDBContextTest()
        {
            var context = new RecordTestDBContext();
            var equipment = new Equipment()
            {
                Mac = "11:22:33:44:55:66",
                Name = "Test Equipment",
                Remark = "备注",
            };
            context.Add(equipment);
            context.SaveChanges();

            var record = new WifiRecord()
            {
                DateTime = DateTime.Now,
                RecordRelations = new List<RecordRelation>(),
            };
            record.RecordRelations.Add(new RecordRelation()
            {
                Equipment = equipment,
                WifiRecord = record
            });
            context.Add(record);
            context.SaveChanges();

            Assert.AreEqual(1, context.Equipments.Count());
            Assert.AreEqual(1, context.RecordRelations.Count());
            Assert.AreEqual(1, context.WifiRecords.Count());
        }
    }
}