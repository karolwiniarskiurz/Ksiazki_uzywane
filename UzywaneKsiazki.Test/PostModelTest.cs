namespace UzywaneKsiazki.Test
{
    using System;
    using System.Collections.Generic;

    using UzywaneKsiazki.Models.DomainModels;

    using Xunit;

    public class PostModelTest
    {


        [Fact]
        public void Can_Join_Images_Link()
        {
            // assing and act its same
            var post = new PostModel
            {
                Photos = new[] { "link1", "link2" },
            };

            // assert
            Assert.Equal(expected: "link1;link2", actual: post.PhotosDb);
        }

        [Fact]
        public void Can_Split_Images_Links()
        {
            var post = new PostModel
            {
                PhotosDb = "link1;link2",
            };

            Assert.Equal(expected: 2, actual: post.Photos.Length);
        }
    }
}