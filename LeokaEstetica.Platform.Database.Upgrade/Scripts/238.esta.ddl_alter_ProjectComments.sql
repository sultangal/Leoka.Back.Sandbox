ALTER TABLE IF EXISTS "Communications"."ProjectComments"
	DROP CONSTRAINT IF EXISTS "FK_ModerationStatuses_StatusId";
	
ALTER TABLE IF EXISTS "Communications"."ProjectComments"
	DROP COLUMN IF EXISTS "ModerationStatusId";
	

ALTER TABLE IF EXISTS "Communications"."ProjectComments"
    ADD COLUMN IF NOT EXISTS "ModerationId" BIGINT NOT NULL,
    ADD CONSTRAINT "FK_ProjectCommentsModeration_ModerationId"
        FOREIGN KEY ("ModerationId")
            REFERENCES "Moderation"."ProjectCommentsModeration" ("ModerationId");
