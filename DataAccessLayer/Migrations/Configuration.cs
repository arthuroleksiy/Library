namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Context.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccessLayer.Context.LibraryDbContext context)
        {
           /* var tag1 = new Tag { TagName = "Fantasy" };
            var tag2 = new Tag { TagName = "Detective" };
            var tag3 = new Tag { TagName = "Biography" };
            var tag4 = new Tag { TagName = "History" };

            var article1 = new Article
            {
                Title = "Silmarillion",
                Date = new DateTime(2020, 04, 24),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum blandit erat at metus ornare consequat. Ut eget mauris dignissim, consequat elit venenatis, tincidunt enim. Donec tempor nulla non venenatis dignissim. Duis vulputate ex et justo imperdiet, et vulputate ligula suscipit. Duis fermentum urna fermentum velit placerat, faucibus porta erat mattis. Duis egestas pulvinar est eu tempor. Proin interdum velit eget accumsan volutpat. Curabitur ut imperdiet ex. Maecenas hendrerit, enim nec lobortis sodales, lacus diam suscipit quam, non vestibulum sem nulla vitae urna. Praesent ac augue tincidunt, hendrerit nulla non, malesuada elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras ultricies tortor nibh, ut tincidunt magna tincidunt sit amet."
                + "Suspendisse quis interdum magna. Mauris sit amet ultricies ante. Nunc eget lacus ac orci vehicula convallis. Morbi ac enim sed enim ornare viverra eu at neque. Sed auctor dignissim elit, eget auctor augue. Duis augue nunc, accumsan ac tincidunt vitae, vehicula sed nulla. Nam rutrum diam in metus rutrum, non pretium mauris sollicitudin. Suspendisse malesuada pellentesque dolor, vel volutpat lectus pharetra eget. Mauris accumsan volutpat odio ac cursus."
                + "Fusce sed velit auctor, rutrum neque sit amet, condimentum justo. Nullam lacinia semper odio, ut accumsan mauris. Sed mollis, ex mattis sollicitudin consequat, odio turpis malesuada nisi, ac tincidunt nulla eros at velit. Maecenas rutrum quam quis arcu interdum, a rutrum turpis dignissim. Sed hendrerit tellus urna, eget auctor velit porttitor vel. Sed neque nulla, tristique eget eros tempus, mattis egestas sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec.",
                Tags = new List<Tag>() { tag1 }
            };
            var article2 = new Article
            {
                Title = "Steve Jobs",
                Date = new DateTime(2020, 04, 25),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum blandit erat at metus ornare consequat. Ut eget mauris dignissim, consequat elit venenatis, tincidunt enim. Donec tempor nulla non venenatis dignissim. Duis vulputate ex et justo imperdiet, et vulputate ligula suscipit. Duis fermentum urna fermentum velit placerat, faucibus porta erat mattis. Duis egestas pulvinar est eu tempor. Proin interdum velit eget accumsan volutpat. Curabitur ut imperdiet ex. Maecenas hendrerit, enim nec lobortis sodales, lacus diam suscipit quam, non vestibulum sem nulla vitae urna. Praesent ac augue tincidunt, hendrerit nulla non, malesuada elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras ultricies tortor nibh, ut tincidunt magna tincidunt sit amet."
                + "Suspendisse quis interdum magna. Mauris sit amet ultricies ante. Nunc eget lacus ac orci vehicula convallis. Morbi ac enim sed enim ornare viverra eu at neque. Sed auctor dignissim elit, eget auctor augue. Duis augue nunc, accumsan ac tincidunt vitae, vehicula sed nulla. Nam rutrum diam in metus rutrum, non pretium mauris sollicitudin. Suspendisse malesuada pellentesque dolor, vel volutpat lectus pharetra eget. Mauris accumsan volutpat odio ac cursus."
                + "Fusce sed velit auctor, rutrum neque sit amet, condimentum justo. Nullam lacinia semper odio, ut accumsan mauris. Sed mollis, ex mattis sollicitudin consequat, odio turpis malesuada nisi, ac tincidunt nulla eros at velit. Maecenas rutrum quam quis arcu interdum, a rutrum turpis dignissim. Sed hendrerit tellus urna, eget auctor velit porttitor vel. Sed neque nulla, tristique eget eros tempus, mattis egestas sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec.",
                Tags = new List<Tag>() { tag3, tag4 }
            };
            var article3 = new Article
            {
                Title = "Game of thrones",
                Date = new DateTime(2020, 04, 27),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum blandit erat at metus ornare consequat. Ut eget mauris dignissim, consequat elit venenatis, tincidunt enim. Donec tempor nulla non venenatis dignissim. Duis vulputate ex et justo imperdiet, et vulputate ligula suscipit. Duis fermentum urna fermentum velit placerat, faucibus porta erat mattis. Duis egestas pulvinar est eu tempor. Proin interdum velit eget accumsan volutpat. Curabitur ut imperdiet ex. Maecenas hendrerit, enim nec lobortis sodales, lacus diam suscipit quam, non vestibulum sem nulla vitae urna. Praesent ac augue tincidunt, hendrerit nulla non, malesuada elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras ultricies tortor nibh, ut tincidunt magna tincidunt sit amet."
                 + "Suspendisse quis interdum magna. Mauris sit amet ultricies ante. Nunc eget lacus ac orci vehicula convallis. Morbi ac enim sed enim ornare viverra eu at neque. Sed auctor dignissim elit, eget auctor augue. Duis augue nunc, accumsan ac tincidunt vitae, vehicula sed nulla. Nam rutrum diam in metus rutrum, non pretium mauris sollicitudin. Suspendisse malesuada pellentesque dolor, vel volutpat lectus pharetra eget. Mauris accumsan volutpat odio ac cursus."
                 + "Fusce sed velit auctor, rutrum neque sit amet, condimentum justo. Nullam lacinia semper odio, ut accumsan mauris. Sed mollis, ex mattis sollicitudin consequat, odio turpis malesuada nisi, ac tincidunt nulla eros at velit. Maecenas rutrum quam quis arcu interdum, a rutrum turpis dignissim. Sed hendrerit tellus urna, eget auctor velit porttitor vel. Sed neque nulla, tristique eget eros tempus, mattis egestas sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec.",
                Tags = new List<Tag>() { tag1 }
            };
            var article4 = new Article
            {
                Title = "Gallic war",
                Date = new DateTime(2020, 04, 30),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum blandit erat at metus ornare consequat. Ut eget mauris dignissim, consequat elit venenatis, tincidunt enim. Donec tempor nulla non venenatis dignissim. Duis vulputate ex et justo imperdiet, et vulputate ligula suscipit. Duis fermentum urna fermentum velit placerat, faucibus porta erat mattis. Duis egestas pulvinar est eu tempor. Proin interdum velit eget accumsan volutpat. Curabitur ut imperdiet ex. Maecenas hendrerit, enim nec lobortis sodales, lacus diam suscipit quam, non vestibulum sem nulla vitae urna. Praesent ac augue tincidunt, hendrerit nulla non, malesuada elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras ultricies tortor nibh, ut tincidunt magna tincidunt sit amet."
                 + "Suspendisse quis interdum magna. Mauris sit amet ultricies ante. Nunc eget lacus ac orci vehicula convallis. Morbi ac enim sed enim ornare viverra eu at neque. Sed auctor dignissim elit, eget auctor augue. Duis augue nunc, accumsan ac tincidunt vitae, vehicula sed nulla. Nam rutrum diam in metus rutrum, non pretium mauris sollicitudin. Suspendisse malesuada pellentesque dolor, vel volutpat lectus pharetra eget. Mauris accumsan volutpat odio ac cursus."
                 + "Fusce sed velit auctor, rutrum neque sit amet, condimentum justo. Nullam lacinia semper odio, ut accumsan mauris. Sed mollis, ex mattis sollicitudin consequat, odio turpis malesuada nisi, ac tincidunt nulla eros at velit. Maecenas rutrum quam quis arcu interdum, a rutrum turpis dignissim. Sed hendrerit tellus urna, eget auctor velit porttitor vel. Sed neque nulla, tristique eget eros tempus, mattis egestas sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec.",
                Tags = new List<Tag>() { tag4 }

            };
            context.Articles.Add(article1);
            context.Articles.Add(article2);
            context.Articles.Add(article3);
            context.Articles.Add(article4);*/
        }
    }
}
