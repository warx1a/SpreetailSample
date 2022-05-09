using NUnit.Framework;
using MultiValueDictionary;
using System.Text;
using System.Collections.Generic;

namespace MultiValueDictionaryUnitTest
{
    public class Tests
    {
        private MultiValueDictionary.MultiValueDictionary mvdToTest;

        [SetUp]
        public void Setup()
        {
            mvdToTest = new MultiValueDictionary.MultiValueDictionary();
        }

        [Test]
        public void AddingTests()
        {
            //reset the dictionary
            Assert.AreEqual(mvdToTest.Clear(), "Cleared");
            string sAddingTest = mvdToTest.Add("testkey", "testval");
            Assert.AreEqual(sAddingTest, "Success", "Adding an item was successful");
            string sRepeatAdd = mvdToTest.Add("testkey", "testval");
            Assert.AreEqual(sRepeatAdd, "ERROR, member already exists for key", "Adding the same items again is not successful");
            Assert.AreEqual(mvdToTest.Members("testkey"), "1) testval\n", "Verify that 'testval' was only entered once");
            //add some items in a loop to populate our dictionary
            for(var i = 0; i < 10; i++)
            {
                string addTest = mvdToTest.Add("loopkey", i.ToString());
                Assert.AreEqual(addTest, "Success", "Adding to dictionary in a loop");
            }
            Assert.AreEqual(mvdToTest.Keys(), "1) testkey\n2) loopkey\n", "Only testkey and loopkey should have been added at this point");
            Assert.AreEqual(mvdToTest.AllMembers(), "1) testval\n2) 0\n3) 1\n4) 2\n5) 3\n6) 4\n7) 5\n8) 6\n9) 7\n10) 8\n11) 9\n", "testval should only have been entered once. along w/ single digits");
            //clear the dictionary, and now check the empty set functions
            Assert.AreEqual(mvdToTest.Clear(), "Cleared");
            Assert.IsTrue(mvdToTest.IsEmpty(), "Verify that the dictionary has 0 members");
            Assert.AreEqual(mvdToTest.Items(), "(empty set)", "Verify that an empty set is returning for the Items call");
            Assert.AreEqual(mvdToTest.Keys(), "(empty set)", "Verify that an empty set is returning for the Keys call");
            Assert.AreEqual(mvdToTest.AllMembers(), "(empty set)", "Verify that an empty set is returning for the AllMembers call");
        }

        [Test(Description = "Tests KeyExists, Members, Remove, and RemoveAll functions")]
        public void RemovingTests()
        {
            mvdToTest.Add("removethis", "val1");
            mvdToTest.Add("removethis", "val2");
            mvdToTest.Add("removethis", "val3");
            
            Assert.IsTrue(mvdToTest.KeyExists("removethis"), "The test key for removal exists in the dictionary");
            Assert.IsTrue(mvdToTest.MemberExists("removethis", "val2"), "The test value for the removal key exists in the dictionary");
            Assert.AreEqual(mvdToTest.Members("removethis"), "1) val1\n2) val2\n3) val3\n", "Values were added successfully to the removal case");
            string sRemoveInvalidKey = mvdToTest.Remove("removaltest", "val1");
            Assert.AreEqual(sRemoveInvalidKey, "ERROR, key does not exist", "Removing an invalid key throws an error");
            string sRemoveInvalidMember = mvdToTest.Remove("removethis", "val20");
            Assert.AreEqual(sRemoveInvalidMember, "ERROR, member does not exist", "Removing an invalid member throws an error");
            string sRemoveMem = mvdToTest.Remove("removethis", "val2");
            Assert.AreEqual(sRemoveMem, "Removed", "Removing a member is successful");
            Assert.AreEqual(mvdToTest.Members("removethis"), "1) val1\n2) val3\n", "There are still 2 values remaining for the test key");
            string sRemoveAllBadKey = mvdToTest.RemoveAll("badkey");
            Assert.AreEqual(sRemoveAllBadKey, "ERROR, key does not exist", "RemoveAll on a non-existent key fails");
            string sRemoveAllTestKey = mvdToTest.RemoveAll("removethis");
            Assert.AreEqual(sRemoveAllTestKey, "Removed", "RemoveAll on valid key is successful");
            string sMembersForKeyAreEmpty = mvdToTest.Members("removethis");
            Assert.AreEqual(sMembersForKeyAreEmpty, "ERROR, key does not exist", "The key isn't in the dictionary now that all values are removed");
        }

        [Test(Description = "Tests the Keys and Members functions")]
        public void KeyMembersTests()
        {
            List<string> sKeys = new List<string>();
            mvdToTest.Clear();
            for(int i = 0; i < 100; i++)
            {
                string sKeyToUse = $"KeysTest-{i}";
                sKeys.Add(sKeyToUse);
                mvdToTest.Add(sKeyToUse, "testval");
            }
            string sKeyToMatch = string.Join(",", sKeys);

        }
    }
}