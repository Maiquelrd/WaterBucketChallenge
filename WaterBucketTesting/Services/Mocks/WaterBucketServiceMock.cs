using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBucketChallenge.Models;

namespace WaterBucketTesting.Services.Mocks
{
    public struct WaterBucketServiceMock
    {
        public static string ShowSteps = "Filled 5 to bucket Y\nTransfer 3 from bucket Y to bucket X\nDumped 3 from bucket X\nTransfer 2 from bucket Y to bucket X\nFilled 5 to bucket Y\nTransfer 1 from bucket Y to bucket X";

        public static List<Step> GetSteps = new List<Step>()
        {
            new Step()
            { 
                Number = 1,
                Action = "Fill",
                Value = 5,
                AffedtedBucket = new Bucket(){
                    Name = "Y",
                    Value = 5,
                    Cap = 5
                },
                ToBucket = null,
                Description = "Filled 5 to bucket Y"
            },
            new Step()
            {
                Number  =   2,
                Action  =   "Transfer",
                Value   =   3,
                AffedtedBucket  = new Bucket(){
                    Name    =   "Y",
                    Value   =   2,
                    Cap = 5 
                },
                ToBucket    =   new Bucket(){
                    Name    =   "X",
                    Value   =   3,
                    Cap =   3
                },
                Description =   "Transfer 3 from bucket Y to bucket X"
            },
            new Step()
            {
                Number = 3,
                Action = "Dump",
                Value = 3,
                AffedtedBucket = new Bucket(){
                    Name = "X",
                    Value = 0,
                    Cap = 3
                },
                ToBucket = null,
                Description = "Dumped 3 from bucket X"
            },
            new Step()
            {
                Number  =   4,
                Action  =   "Transfer",
                Value   =   2,
                AffedtedBucket  = new Bucket(){
                    Name    =   "Y",
                    Value   =   0,
                    Cap = 5
                },
                ToBucket    =   new Bucket(){
                    Name    =   "X",
                    Value   =   2,
                    Cap =   3
                },
                Description =   "Transfer 2 from bucket Y to bucket X"
            },
             new Step()
            {
                Number = 5,
                Action = "Fill",
                Value = 5,
                AffedtedBucket = new Bucket(){
                    Name = "Y",
                    Value = 5,
                    Cap = 5
                },
                ToBucket = null,
                Description = "Filled 5 to bucket Y"
            },
             new Step()
            {
                Number  =   6,
                Action  =   "Transfer",
                Value   =   1,
                AffedtedBucket  = new Bucket(){
                    Name    =   "Y",
                    Value   =   4,
                    Cap = 5
                },
                ToBucket    =   new Bucket(){
                    Name    =   "X",
                    Value   =   3,
                    Cap =   3
                },
                Description =   "Transfer 1 from bucket Y to bucket X"
            },
        };



        public static List<Step> GetSteps2 = new List<Step>()
        {
            new Step()
            {
                Number = 1,
                Action = "Fill",
                Value = 3,
                AffedtedBucket = new Bucket(){
                    Name = "X",
                    Value = 3,
                    Cap = 3
                },
                ToBucket = null,
                Description = "Filled 3 to bucket X"
            },
            new Step()
            {
                Number  =   2,
                Action  =   "Transfer",
                Value   =   3,
                AffedtedBucket  = new Bucket(){
                    Name    =   "X",
                    Value   =   0,
                    Cap = 3
                },
                ToBucket    =   new Bucket(){
                    Name    =   "Y",
                    Value   =   3,
                    Cap =   5
                },
                Description =   "Transfer 3 from bucket X to bucket Y"
            },
            new Step()
            {
                Number = 3,
                Action = "Fill",
                Value = 3,
                AffedtedBucket = new Bucket(){
                    Name = "X",
                    Value = 3,
                    Cap = 3
                },
                ToBucket = null,
                Description = "Filled 3 to bucket X"
            },
            new Step()
            {
                Number  =   4,
                Action  =   "Transfer",
                Value   =   2,
                AffedtedBucket  = new Bucket(){
                    Name    =   "X",
                    Value   =   1,
                    Cap = 3
                },
                ToBucket    =   new Bucket(){
                    Name    =   "Y",
                    Value   =   5,
                    Cap =   5
                },
                Description =   "Transfer 2 from bucket X to bucket Y"
            },
             new Step()
            {
                Number = 5,
                Action = "Dump",
                Value = 5,
                AffedtedBucket = new Bucket(){
                    Name = "Y",
                    Value = 0,
                    Cap = 5
                },
                ToBucket = null,
                Description = "Dumped 5 from bucket Y"
            },
             new Step()
            {
                Number  =   6,
                Action  =   "Transfer",
                Value   =   1,
                AffedtedBucket  = new Bucket(){
                    Name    =   "X",
                    Value   =   0,
                    Cap = 3
                },
                ToBucket    =   new Bucket(){
                    Name    =   "Y",
                    Value   =   1,
                    Cap =   5
                },
                Description =   "Transfer 1 from bucket X to bucket Y"
            },
              new Step()
            {
                Number = 7,
                Action = "Fill",
                Value = 3,
                AffedtedBucket = new Bucket(){
                    Name = "X",
                    Value = 3,
                    Cap = 3
                },
                ToBucket = null,
                Description = "Filled 3 to bucket X"
            },
              new Step()
            {
                Number  =   8,
                Action  =   "Transfer",
                Value   =   3,
                AffedtedBucket  = new Bucket(){
                    Name    =   "X",
                    Value   =   0,
                    Cap = 3
                },
                ToBucket    =   new Bucket(){
                    Name    =   "Y",
                    Value   =   4,
                    Cap =   5
                },
                Description =   "Transfer 3 from bucket X to bucket Y"
            },
        };
    }
}
