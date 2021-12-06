using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Mock.Data
{

    public class MockedParts
    {
        public List<Parts> MockParts { get; set; }

        public MockedParts()
        {
            GetData();
        }
        /// <summary>
        /// sets the value of MockParts with the data from the "database" (actualy it's mocked)
        /// </summary>
        private void GetData()
        {
            MockParts = new List<Parts>();


            //Compatible parts

            Parts partCompatible1 = new Parts
            {
                Description = "Front ligth right Toyota Hilux Generic",
                PartId = "1001",
                PartCode= "FrontLightR2020G",
                Price = 80,
                Brand = new Brand { Id = 1, Name = "Toyota" }
            };

            MockParts.Add(partCompatible1);

            Parts partCompatible2 = new Parts
            {
                Description = "Front ligth left Toyota Hilux Generic",
                PartId = "1002",
                PartCode = "FrontLightL2020G",
                Price = 80,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(partCompatible2);

            Parts partCompatible3 = new Parts
            {
                Description = "rear ligth right Toyota Estima Generic",
                PartId = "1003",
                PartCode = "RearLightR2019G",
                Price = 50,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(partCompatible3);

            Parts partCompatible4 = new Parts
            {
                Description = "Rear ligth left Toyota Estima Generic",
                PartId = "1004",
                PartCode = "RearLightL2019G",
                Price = 80,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(partCompatible4);

            Parts partCompatible5 = new Parts
            {
                Description = "Front ligth Toyota Generic",
                PartId = "1005",
                PartCode = "FrontLight2020G",
                Price = 75,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(partCompatible5);

            Parts partCompatible6 = new Parts
            {
                Description = "Rear ligth Toyota Generic",
                PartId = "1006",
                PartCode = "RearLight2020G",
                Price = 75,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(partCompatible6);


            //Toyota Hilux 2020
            Parts part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible1, partCompatible5 },
                Description = "Front ligth right Toyota Hilux 2020",
                PartId = "1101",
                PartCode = "FrontLightR2020",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);
            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible2, partCompatible5 },
                Description = "Front ligth left Toyota Hilux 2020",
                PartId = "1102",
                PartCode = "FrontLightL2020",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);
            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible6 },

                Description = "rear ligth left Toyota Hilux 2020",
                PartId = "1103",
                PartCode = "ReartLightL2020",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);
            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible6 },

                Description = "rear ligth right Toyota Hilux 2020",
                PartId = "1104",
                PartCode = "ReartLightR2020",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);


            //Toyota Estima 2019
            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible5 },
                Description = "Front ligth right Toyota Estima 2019",
                PartId = "1201",
                PartCode = "FrontLightR2019",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);

            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible5 },
                Description = "Front ligth left Toyota Estima 2019",
                PartId = "1202",
                PartCode = "FrontLightL2019",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);

            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible3, partCompatible6 },
                Description = "rear ligth left Toyota Estima 2019",
                PartId = "1203",
                PartCode = "RearLightL2019",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);

            part = new Parts
            {
                CompatibleParts = new List<Parts> { partCompatible4, partCompatible6 },
                Description = "Rear ligth right Toyota Estima 2019",
                PartId = "1204",
                PartCode = "RearLightR2019",
                Price = 100,
                Brand = new Brand { Id = 1, Name = "Toyota" }

            };
            MockParts.Add(part);


            //Ford Focus 2015
            Parts FFpart2 = new Parts
            {
                Description = "Generic Break Ford Focus 2015",
                PartId = "1302",
                PartCode = "BreakFF2015G",
                Price = 123,
                Brand = new Brand { Id = 2, Name = "Ford" }

            };
            MockParts.Add(FFpart2);

            Parts FFpart1 = new Parts
            {
                CompatibleParts = new List<Parts> { FFpart2 },
                Description = "Break Ford Focus 2015",
                PartId = "1301",
                PartCode = "BreakFF2015",
                Price = 200,
                Brand = new Brand { Id = 2, Name = "Ford" }

            };
            MockParts.Add(FFpart1);



            Parts FFpart3 = new Parts
            {
                Description = "Generic stereo Ford Focus 2015",
                PartId = "1303",
                PartCode = "Stereo2015G",
                Price = 100,
                Brand = new Brand { Id = 2, Name = "Ford" }

            };
            MockParts.Add(FFpart3);

            part = new Parts
            {
                CompatibleParts = new List<Parts> { FFpart3 },
                Description = "Max stereo Ford Focus 2015",
                PartId = "1304",
                PartCode = "MaxStereo2015",
                Price = 100,
                Brand = new Brand { Id = 2, Name = "Ford" }

            };
            MockParts.Add(part);
        }

    }
}
