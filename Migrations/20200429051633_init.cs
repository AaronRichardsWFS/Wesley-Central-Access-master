using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WCAProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_desc = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false),
                    credible = table.Column<string>(maxLength: 255, nullable: true),
                    temp = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zaction",
                columns: table => new
                {
                    ZactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaction", x => x.ZactionId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zcaresreason",
                columns: table => new
                {
                    ZcaresreasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caresreason = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zcaresreason", x => x.ZcaresreasonId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zcounty",
                columns: table => new
                {
                    ZcountyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    county = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zcounty", x => x.ZcountyId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zhearabout",
                columns: table => new
                {
                    ZhearaboutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hearabout = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zhearabout", x => x.ZhearaboutId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zinsurance",
                columns: table => new
                {
                    ZinsuranceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insurance = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zinsurance", x => x.ZinsuranceId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zinternal",
                columns: table => new
                {
                    ZinternalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internal_type = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false),
                    credstatus = table.Column<string>(maxLength: 255, nullable: true),
                    temp = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zinternal", x => x.ZinternalId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zinternalcategory",
                columns: table => new
                {
                    ZinternalcategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internalsubcat = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zinternalcategory", x => x.ZinternalcategoryId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zlocation",
                columns: table => new
                {
                    ZlocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false),
                    credstatus = table.Column<string>(maxLength: 255, nullable: true),
                    temp = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlocation", x => x.ZlocationId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zopother",
                columns: table => new
                {
                    ZopotherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opother = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zopother", x => x.ZopotherId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zplatform",
                columns: table => new
                {
                    ZplatformId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internalId = table.Column<int>(nullable: true),
                    opplatform = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zplatform", x => x.ZplatformId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zprograms",
                columns: table => new
                {
                    ZprogramsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    programs_id = table.Column<string>(maxLength: 255, nullable: true),
                    program_desc = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zprograms", x => x.ZprogramsId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zrace",
                columns: table => new
                {
                    ZraceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race = table.Column<string>(maxLength: 50, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zrace", x => x.ZraceId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zreason",
                columns: table => new
                {
                    ZreasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    final_reason = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false),
                    status_match = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zreason", x => x.ZreasonId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zreferralsource",
                columns: table => new
                {
                    ZreferralsourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    referralsource = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zreferralsource", x => x.ZreferralsourceId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zresourcereason",
                columns: table => new
                {
                    ZresourcereasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resourceresult = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zresourcereason", x => x.ZresourcereasonId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zschool",
                columns: table => new
                {
                    ZschoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    site = table.Column<string>(maxLength: 255, nullable: true),
                    schooldistrict = table.Column<string>(maxLength: 255, nullable: true),
                    displayname = table.Column<string>(maxLength: 255, nullable: true),
                    therapist = table.Column<string>(maxLength: 255, nullable: true),
                    ServiceOffered = table.Column<string>(maxLength: 255, nullable: true),
                    Supervisor = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zschool", x => x.ZschoolId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zsite",
                columns: table => new
                {
                    ZsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    site = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zsite", x => x.ZsiteId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zstatus",
                columns: table => new
                {
                    ZstatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inq_status = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false),
                    credstatus = table.Column<string>(maxLength: 255, nullable: true),
                    temp = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zstatus", x => x.ZstatusId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zworker",
                columns: table => new
                {
                    ZworkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    worker = table.Column<string>(maxLength: 255, nullable: true),
                    report = table.Column<string>(maxLength: 255, nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zworker", x => x.ZworkerId);
                });
            
            migrationBuilder.CreateTable(
                name: "Zyesno",
                columns: table => new
                {
                    ZyesnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yesno = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zyesno", x => x.ZyesnoId);
                });
            
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZcountyId = table.Column<int>(nullable: true),
                    ZraceId = table.Column<int>(nullable: true),
                    ZinsuranceId = table.Column<int>(nullable: true),
                    insurance2 = table.Column<string>(nullable: true),
                    cfirst = table.Column<string>(nullable: true),
                    clast = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    email2 = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    phone2 = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(nullable: true),
                    ssn = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: true),
                    ins_other = table.Column<string>(nullable: true),
                    ins_note = table.Column<string>(nullable: true),
                    ins_other_note = table.Column<string>(nullable: true),
                    CredibleID = table.Column<string>(nullable: true),
                    nextactionnote = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    contact2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Zcounty_ZcountyId",
                        column: x => x.ZcountyId,
                        principalTable: "Zcounty",
                        principalColumn: "ZcountyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Zinsurance_ZinsuranceId",
                        column: x => x.ZinsuranceId,
                        principalTable: "Zinsurance",
                        principalColumn: "ZinsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Zrace_ZraceId",
                        column: x => x.ZraceId,
                        principalTable: "Zrace",
                        principalColumn: "ZraceId",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ClientServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true),
                    ZcaresreasonId = table.Column<int>(nullable: true),
                    ZhearaboutId = table.Column<int>(nullable: true),
                    ZinternalId = table.Column<int>(nullable: true),
                    ZinternalcategoryId = table.Column<int>(nullable: true),
                    ZlocationId = table.Column<int>(nullable: true),
                    ZopotherId = table.Column<int>(nullable: true),
                    ZplatformId = table.Column<int>(nullable: true),
                    ZprogramsId = table.Column<int>(nullable: true),
                    ZresourcereasonId = table.Column<int>(nullable: true),
                    ZsiteId = table.Column<int>(nullable: true),
                    ZschoolId = table.Column<int>(nullable: true),
                    site2 = table.Column<string>(nullable: true),
                    ZstatusId = table.Column<int>(nullable: true),
                    ZreasonId = table.Column<int>(nullable: true),
                    ZworkerId = table.Column<int>(nullable: true),
                    recdate = table.Column<DateTime>(nullable: true),
                    site_other = table.Column<string>(nullable: true),
                    diagnosis = table.Column<string>(nullable: true),
                    drug = table.Column<string>(nullable: true),
                    child = table.Column<string>(nullable: true),
                    closedate = table.Column<DateTime>(nullable: true),
                    court = table.Column<string>(nullable: true),
                    eval_date = table.Column<string>(nullable: true),
                    bhrs_diag = table.Column<string>(nullable: true),
                    prescription = table.Column<string>(nullable: true),
                    family_avail = table.Column<string>(nullable: true),
                    psychologist = table.Column<string>(nullable: true),
                    pocdates = table.Column<string>(nullable: true),
                    intext = table.Column<string>(nullable: true),
                    intnote = table.Column<string>(nullable: true),
                    exttype = table.Column<string>(nullable: true),
                    extnote = table.Column<string>(nullable: true),
                    trackdate = table.Column<string>(nullable: true),
                    tracknote = table.Column<string>(nullable: true),
                    treatment = table.Column<string>(nullable: true),
                    harm = table.Column<string>(nullable: true),
                    homeloc = table.Column<string>(nullable: true),
                    schoolloc = table.Column<string>(nullable: true),
                    substance = table.Column<string>(nullable: true),
                    optype = table.Column<string>(nullable: true),
                    legal = table.Column<string>(nullable: true),
                    withdraw = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.ClientServiceId);
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zcaresreason_ZcaresreasonId",
                        column: x => x.ZcaresreasonId,
                        principalTable: "Zcaresreason",
                        principalColumn: "ZcaresreasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zhearabout_ZhearaboutId",
                        column: x => x.ZhearaboutId,
                        principalTable: "Zhearabout",
                        principalColumn: "ZhearaboutId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zinternal_ZinternalId",
                        column: x => x.ZinternalId,
                        principalTable: "Zinternal",
                        principalColumn: "ZinternalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zinternalcategory_ZinternalcategoryId",
                        column: x => x.ZinternalcategoryId,
                        principalTable: "Zinternalcategory",
                        principalColumn: "ZinternalcategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zlocation_ZlocationId",
                        column: x => x.ZlocationId,
                        principalTable: "Zlocation",
                        principalColumn: "ZlocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zopother_ZopotherId",
                        column: x => x.ZopotherId,
                        principalTable: "Zopother",
                        principalColumn: "ZopotherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zplatform_ZplatformId",
                        column: x => x.ZplatformId,
                        principalTable: "Zplatform",
                        principalColumn: "ZplatformId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zprograms_ZprogramsId",
                        column: x => x.ZprogramsId,
                        principalTable: "Zprograms",
                        principalColumn: "ZprogramsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zreason_ZreasonId",
                        column: x => x.ZreasonId,
                        principalTable: "Zreason",
                        principalColumn: "ZreasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zresourcereason_ZresourcereasonId",
                        column: x => x.ZresourcereasonId,
                        principalTable: "Zresourcereason",
                        principalColumn: "ZresourcereasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zschool_ZschoolId",
                        column: x => x.ZschoolId,
                        principalTable: "Zschool",
                        principalColumn: "ZschoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zsite_ZsiteId",
                        column: x => x.ZsiteId,
                        principalTable: "Zsite",
                        principalColumn: "ZsiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zstatus_ZstatusId",
                        column: x => x.ZstatusId,
                        principalTable: "Zstatus",
                        principalColumn: "ZstatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientServices_Zworker_ZworkerId",
                        column: x => x.ZworkerId,
                        principalTable: "Zworker",
                        principalColumn: "ZworkerId",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateTable(
                name: "Clineitems",
                columns: table => new
                {
                    ClineitemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientServiceId = table.Column<int>(nullable: true),
                    ZworkerId = table.Column<int>(nullable: true),
                    ldate = table.Column<DateTime>(nullable: true),
                    action = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clineitems", x => x.ClineitemId);
                    table.ForeignKey(
                        name: "FK_Clineitems_ClientServices_ClientServiceId",
                        column: x => x.ClientServiceId,
                        principalTable: "ClientServices",
                        principalColumn: "ClientServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clineitems_Zworker_ZworkerId",
                        column: x => x.ZworkerId,
                        principalTable: "Zworker",
                        principalColumn: "ZworkerId",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateTable(
                name: "ScaScreen",
                columns: table => new
                {
                    ScaScreenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: true),
                    ClientServiceId = table.Column<int>(nullable: true),
                    wsclinic = table.Column<int>(nullable: true),
                    referralsource = table.Column<string>(maxLength: 50, nullable: true),
                    whyfamilyseen = table.Column<string>(maxLength: 500, nullable: true),
                    treatmenthistory = table.Column<string>(maxLength: 50, nullable: true),
                    asddiagnosis = table.Column<string>(maxLength: 50, nullable: true),
                    halfwayshelter = table.Column<string>(maxLength: 50, nullable: true),
                    recentlymove = table.Column<string>(maxLength: 50, nullable: true),
                    outsidevbh = table.Column<string>(maxLength: 50, nullable: true),
                    meetcriteria = table.Column<string>(maxLength: 50, nullable: true),
                    referraldetails = table.Column<string>(maxLength: 500, nullable: true),
                    shelterdetails = table.Column<string>(maxLength: 500, nullable: true),
                    wasstatenotified = table.Column<string>(maxLength: 50, nullable: true),
                    gennote = table.Column<string>(maxLength: 500, nullable: true),
                    privateinsurer = table.Column<string>(maxLength: 250, nullable: true),
                    privateinsurance = table.Column<string>(maxLength: 50, nullable: true),
                    managedcaretype = table.Column<string>(maxLength: 50, nullable: true),
                    requestedlocation = table.Column<string>(maxLength: 50, nullable: true),
                    servicerequested = table.Column<string>(maxLength: 50, nullable: true),
                    currentcounty = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaScreen", x => x.ScaScreenId);
                    table.ForeignKey(
                        name: "FK_ScaScreen_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScaScreen_ClientServices_ClientServiceId",
                        column: x => x.ClientServiceId,
                        principalTable: "ClientServices",
                        principalColumn: "ClientServiceId",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_Clients_ZcountyId",
                table: "Clients",
                column: "ZcountyId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Clients_ZinsuranceId",
                table: "Clients",
                column: "ZinsuranceId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Clients_ZraceId",
                table: "Clients",
                column: "ZraceId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices",
                column: "ClientId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZcaresreasonId",
                table: "ClientServices",
                column: "ZcaresreasonId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZhearaboutId",
                table: "ClientServices",
                column: "ZhearaboutId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZinternalId",
                table: "ClientServices",
                column: "ZinternalId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZinternalcategoryId",
                table: "ClientServices",
                column: "ZinternalcategoryId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZlocationId",
                table: "ClientServices",
                column: "ZlocationId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZopotherId",
                table: "ClientServices",
                column: "ZopotherId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZplatformId",
                table: "ClientServices",
                column: "ZplatformId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZprogramsId",
                table: "ClientServices",
                column: "ZprogramsId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZreasonId",
                table: "ClientServices",
                column: "ZreasonId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZresourcereasonId",
                table: "ClientServices",
                column: "ZresourcereasonId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZschoolId",
                table: "ClientServices",
                column: "ZschoolId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZsiteId",
                table: "ClientServices",
                column: "ZsiteId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZstatusId",
                table: "ClientServices",
                column: "ZstatusId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ZworkerId",
                table: "ClientServices",
                column: "ZworkerId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Clineitems_ClientServiceId",
                table: "Clineitems",
                column: "ClientServiceId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Clineitems_ZworkerId",
                table: "Clineitems",
                column: "ZworkerId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ScaScreen_ClientId",
                table: "ScaScreen",
                column: "ClientId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ScaScreen_ClientServiceId",
                table: "ScaScreen",
                column: "ClientServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clineitems");
            
            migrationBuilder.DropTable(
                name: "ScaScreen");
            
            migrationBuilder.DropTable(
                name: "Zaction");
            
            migrationBuilder.DropTable(
                name: "Zreferralsource");
            
            migrationBuilder.DropTable(
                name: "Zyesno");
            
            migrationBuilder.DropTable(
                name: "ClientServices");
            
            migrationBuilder.DropTable(
                name: "Clients");
            
            migrationBuilder.DropTable(
                name: "Services");
            
            migrationBuilder.DropTable(
                name: "Zcaresreason");
            
            migrationBuilder.DropTable(
                name: "Zhearabout");
            
            migrationBuilder.DropTable(
                name: "Zinternal");
            
            migrationBuilder.DropTable(
                name: "Zinternalcategory");
            
            migrationBuilder.DropTable(
                name: "Zlocation");
            
            migrationBuilder.DropTable(
                name: "Zopother");
            
            migrationBuilder.DropTable(
                name: "Zplatform");
            
            migrationBuilder.DropTable(
                name: "Zprograms");
            
            migrationBuilder.DropTable(
                name: "Zreason");
            
            migrationBuilder.DropTable(
                name: "Zresourcereason");
            
            migrationBuilder.DropTable(
                name: "Zschool");
            
            migrationBuilder.DropTable(
                name: "Zsite");
            
            migrationBuilder.DropTable(
                name: "Zstatus");
            
            migrationBuilder.DropTable(
                name: "Zworker");
            
            migrationBuilder.DropTable(
                name: "Zcounty");
            
            migrationBuilder.DropTable(
                name: "Zinsurance");
            
            migrationBuilder.DropTable(
                name: "Zrace");
        }
    }
}
