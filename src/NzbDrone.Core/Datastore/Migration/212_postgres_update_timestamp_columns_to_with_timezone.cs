using System;
using System.Collections.Generic;
using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(212)]
    public class postgres_update_timestamp_columns_to_with_timezone : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("Blocklist").AlterColumn("Date").AsDateTimeOffset().NotNullable();
            Alter.Table("Blocklist").AlterColumn("PublishedDate").AsDateTimeOffset().Nullable();
            Alter.Table("Collections").AlterColumn("Added").AsDateTimeOffset().Nullable();
            Alter.Table("Collections").AlterColumn("LastInfoSync").AsDateTimeOffset().Nullable();
            Alter.Table("Commands").AlterColumn("QueuedAt").AsDateTimeOffset().NotNullable();
            Alter.Table("Commands").AlterColumn("StartedAt").AsDateTimeOffset().Nullable();
            Alter.Table("Commands").AlterColumn("EndedAt").AsDateTimeOffset().Nullable();
            Alter.Table("DownloadClientStatus").AlterColumn("InitialFailure").AsDateTimeOffset().Nullable();
            Alter.Table("DownloadClientStatus").AlterColumn("MostRecentFailure").AsDateTimeOffset().Nullable();
            Alter.Table("DownloadClientStatus").AlterColumn("DisabledTill").AsDateTimeOffset().Nullable();
            Alter.Table("DownloadHistory").AlterColumn("Date").AsDateTimeOffset().NotNullable();
            Alter.Table("ExtraFiles").AlterColumn("Added").AsDateTimeOffset().NotNullable();
            Alter.Table("ExtraFiles").AlterColumn("LastUpdated").AsDateTimeOffset().NotNullable();
            Alter.Table("History").AlterColumn("Date").AsDateTimeOffset().NotNullable();
            Alter.Table("ImportListStatus").AlterColumn("InitialFailure").AsDateTimeOffset().Nullable();
            Alter.Table("ImportListStatus").AlterColumn("MostRecentFailure").AsDateTimeOffset().Nullable();
            Alter.Table("ImportListStatus").AlterColumn("DisabledTill").AsDateTimeOffset().Nullable();
            Alter.Table("IndexerStatus").AlterColumn("InitialFailure").AsDateTimeOffset().Nullable();
            Alter.Table("IndexerStatus").AlterColumn("MostRecentFailure").AsDateTimeOffset().Nullable();
            Alter.Table("IndexerStatus").AlterColumn("DisabledTill").AsDateTimeOffset().Nullable();
            Alter.Table("IndexerStatus").AlterColumn("CookiesExpirationDate").AsDateTimeOffset().Nullable();
            Alter.Table("MetadataFiles").AlterColumn("LastUpdated").AsDateTimeOffset().NotNullable();
            Alter.Table("MetadataFiles").AlterColumn("Added").AsDateTimeOffset().Nullable();
            Alter.Table("MovieFiles").AlterColumn("DateAdded").AsDateTimeOffset().NotNullable();
            Alter.Table("MovieMetadata").AlterColumn("DigitalRelease").AsDateTimeOffset().Nullable();
            Alter.Table("MovieMetadata").AlterColumn("InCinemas").AsDateTimeOffset().Nullable();
            Alter.Table("MovieMetadata").AlterColumn("LastInfoSync").AsDateTimeOffset().Nullable();
            Alter.Table("MovieMetadata").AlterColumn("PhysicalRelease").AsDateTimeOffset().Nullable();
            Alter.Table("Movies").AlterColumn("Added").AsDateTimeOffset().Nullable();
            Alter.Table("PendingReleases").AlterColumn("Added").AsDateTimeOffset().NotNullable();
            Alter.Table("ScheduledTasks").AlterColumn("LastExecution").AsDateTimeOffset().NotNullable();
            Alter.Table("ScheduledTasks").AlterColumn("LastStartTime").AsDateTimeOffset().Nullable();
            Alter.Table("SubtitleFiles").AlterColumn("Added").AsDateTimeOffset().NotNullable();
            Alter.Table("SubtitleFiles").AlterColumn("LastUpdated").AsDateTimeOffset().NotNullable();
            Alter.Table("VersionInfo").AlterColumn("AppliedOn").AsDateTimeOffset().Nullable();
        }

        protected override void LogDbUpgrade()
        {
            Alter.Table("Logs").AlterColumn("Time").AsDateTimeOffset().NotNullable();
            Alter.Table("UpdateHistory").AlterColumn("Date").AsDateTimeOffset().NotNullable();
            Alter.Table("VersionInfo").AlterColumn("AppliedOn").AsDateTimeOffset().Nullable();
        }
    }
}
