using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.Movies
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition("Movie", builder=>
            builder.WithPart("CommonPart")
            .WithPart("TitlePart")
            .WithPart("AutoRoutePart"));
            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("Movie", builder =>
            builder.WithPart("BodyPart")
            .Creatable()
            .Draftable());
            return 2;
        }
        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition("Movie", builder =>
                builder.WithPart("BodyPart", partBuilder =>
                partBuilder.WithSetting("BodyTypePartSettings.Flavor", "text"))
            .WithPart("AutoroutePart",partBuilder=>
            partBuilder
            .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Movie Title', Pattern: 'movies/{Content.Slug}', Description: 'movies/movie-title'}, {Name:'Film Title', Pattern: 'films/{Content.Slug}', Description: 'films/film-title'}]")
                        .WithSetting("AutorouteSettings.DefaultPatternIndex", "0")));
            return 3;
        }
    }
   
}