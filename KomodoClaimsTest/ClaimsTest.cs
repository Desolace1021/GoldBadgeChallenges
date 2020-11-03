using System;
using KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KomodoClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {

        KomodoClaims_Repo _claimRepo = new KomodoClaims_Repo();

        //test - AddClaimToDirectory(ClaimsMenu claims)

        [TestMethod]
        public void CheckAddClaimToDirectory_AndGetitems()
        {
            ClaimsMenu claim = new ClaimsMenu();
            Queue<ClaimsMenu> _queue = _claimRepo.Getitems();

            _claimRepo.AddClaimToDirectory(claim);

            int expectedResult = 1;
            int actualResult = _queue.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
