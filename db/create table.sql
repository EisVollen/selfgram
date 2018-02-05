-- Database: selfgram
-- Table: public."AspNetUsers"

-- DROP TABLE public."AspNetUsers";

CREATE TABLE public."AspNetUsers"
(
    "Id" uuid NOT NULL,
    "AccessFailedCount" integer NOT NULL,
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    "Email" character varying(256) COLLATE pg_catalog."default",
    "EmailConfirmed" boolean NOT NULL,
    "LockoutEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "NormalizedEmail" character varying(256) COLLATE pg_catalog."default",
    "NormalizedUserName" character varying(256) COLLATE pg_catalog."default",
    "PasswordHash" text COLLATE pg_catalog."default",
    "PhoneNumber" text COLLATE pg_catalog."default",
    "PhoneNumberConfirmed" boolean NOT NULL,
    "SecurityStamp" text COLLATE pg_catalog."default",
    "TwoFactorEnabled" boolean NOT NULL,
    "UserName" character varying(256) COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUsers"
    OWNER to postgres;
	
	-- Table: public."AspNetRoles"

-- DROP TABLE public."AspNetRoles";

CREATE TABLE public."AspNetRoles"
(
    "Id" uuid NOT NULL,
    "ConcurrencyStamp" text COLLATE pg_catalog."default",
    "Name" character varying(256) COLLATE pg_catalog."default",
    "NormalizedName" character varying(256) COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetRoles"
    OWNER to postgres;

-- Index: RoleNameIndex

-- DROP INDEX public."RoleNameIndex";

CREATE INDEX "RoleNameIndex"
    ON public."AspNetRoles" USING btree
    ("NormalizedName" COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: EmailIndex

-- DROP INDEX public."EmailIndex";

CREATE INDEX "EmailIndex"
    ON public."AspNetUsers" USING btree
    ("NormalizedEmail" COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: UserNameIndex

-- DROP INDEX public."UserNameIndex";

CREATE UNIQUE INDEX "UserNameIndex"
    ON public."AspNetUsers" USING btree
    ("NormalizedUserName" COLLATE pg_catalog."default")
    TABLESPACE pg_default;
	
	
CREATE TABLE public."AspNetUserTokens"
(
    "UserId" uuid NOT NULL,
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Value" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserTokens"
    OWNER to postgres;
	-- Table: public."AspNetUserRoles"

-- DROP TABLE public."AspNetUserRoles";

CREATE TABLE public."AspNetUserRoles"
(
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES public."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserRoles"
    OWNER to postgres;
-- Table: public."AspNetRoleClaims"

-- DROP TABLE public."AspNetRoleClaims";

CREATE TABLE public."AspNetRoleClaims"
(
    "Id" integer NOT NULL,
    "ClaimType" text COLLATE pg_catalog."default",
    "ClaimValue" text COLLATE pg_catalog."default",
    "RoleId" uuid NOT NULL,
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId")
        REFERENCES public."AspNetRoles" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetRoleClaims"
    OWNER to postgres;

-- Index: IX_AspNetRoleClaims_RoleId

-- DROP INDEX public."IX_AspNetRoleClaims_RoleId";

CREATE INDEX "IX_AspNetRoleClaims_RoleId"
    ON public."AspNetRoleClaims" USING btree
    ("RoleId")
    TABLESPACE pg_default;
-- Index: IX_AspNetUserRoles_RoleId

-- DROP INDEX public."IX_AspNetUserRoles_RoleId";

CREATE INDEX "IX_AspNetUserRoles_RoleId"
    ON public."AspNetUserRoles" USING btree
    ("RoleId")
    TABLESPACE pg_default;

-- Index: IX_AspNetUserRoles_UserId

-- DROP INDEX public."IX_AspNetUserRoles_UserId";

CREATE INDEX "IX_AspNetUserRoles_UserId"
    ON public."AspNetUserRoles" USING btree
    ("UserId")
    TABLESPACE pg_default;
	
	-- Table: public."AspNetUserClaims"

-- DROP TABLE public."AspNetUserClaims";

CREATE TABLE public."AspNetUserClaims"
(
    "Id" integer NOT NULL,
    "ClaimType" text COLLATE pg_catalog."default",
    "ClaimValue" text COLLATE pg_catalog."default",
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserClaims"
    OWNER to postgres;

-- Index: IX_AspNetUserClaims_UserId

-- DROP INDEX public."IX_AspNetUserClaims_UserId";

CREATE INDEX "IX_AspNetUserClaims_UserId"
    ON public."AspNetUserClaims" USING btree
    ("UserId")
    TABLESPACE pg_default;
	
	-- Table: public."AspNetUserLogins"

-- DROP TABLE public."AspNetUserLogins";

CREATE TABLE public."AspNetUserLogins"
(
    "LoginProvider" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderKey" text COLLATE pg_catalog."default" NOT NULL,
    "ProviderDisplayName" text COLLATE pg_catalog."default",
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."AspNetUserLogins"
    OWNER to postgres;

-- Index: IX_AspNetUserLogins_UserId

-- DROP INDEX public."IX_AspNetUserLogins_UserId";

CREATE INDEX "IX_AspNetUserLogins_UserId"
    ON public."AspNetUserLogins" USING btree
    ("UserId")
    TABLESPACE pg_default;
	
	-- Table: public."Publications"

-- DROP TABLE public."Publications";

CREATE TABLE public."Publications"
(
    id uuid NOT NULL,
    header character varying(40) COLLATE pg_catalog."default",
    image_path character varying(256) COLLATE pg_catalog."default" NOT NULL,
    tags character varying(1024) COLLATE pg_catalog."default",
    author_id uuid NOT NULL,
    public_date timestamp with time zone NOT NULL,
    CONSTRAINT "Publication_pkey" PRIMARY KEY (id),
    CONSTRAINT "Publication_author_id_fkey" FOREIGN KEY (author_id)
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Publications"
    OWNER to postgres;
	-- Table: public."Likes"

-- DROP TABLE public."Likes";

CREATE TABLE public."Likes"
(
    id uuid NOT NULL,
    "user_id" uuid NOT NULL,
    publication_id uuid NOT NULL,
    CONSTRAINT "Likes_pkey" PRIMARY KEY (id),
    CONSTRAINT "Likes_publication_fkey" FOREIGN KEY (publication_id)
        REFERENCES public."Publications" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Likes_user_fkey" FOREIGN KEY ("user_id")
        REFERENCES public."AspNetUsers" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Likes"
    OWNER to postgres;

-- Index: likes_user_publication

-- DROP INDEX public.likes_user_publication;

CREATE UNIQUE INDEX likes_user_publication
    ON public."Likes" USING btree
    ("user_id", publication_id)
    TABLESPACE pg_default;