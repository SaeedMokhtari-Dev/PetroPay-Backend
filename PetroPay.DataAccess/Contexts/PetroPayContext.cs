using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetroPay.DataAccess.Entities;
using TestScaffold.Models;

#nullable disable

namespace PetroPay.DataAccess.Contexts
{
    public partial class PetroPayContext : DbContext
    {
        private readonly string _connectionString;
        
        public PetroPayContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public PetroPayContext(DbContextOptions<PetroPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountMaster> AccountMasters { get; set; }
        public virtual DbSet<Apidatum> Apidata { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrandMaster> CarBrandMasters { get; set; }
        public virtual DbSet<CarModelMaster> CarModelMasters { get; set; }
        public virtual DbSet<CarSubscription> CarSubscriptions { get; set; }
        public virtual DbSet<CarTypeMaster> CarTypeMasters { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }
        public virtual DbSet<EmployeeMenu> EmployeeMenus { get; set; }
        public virtual DbSet<Emplyee> Emplyees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<NewCustomer> NewCustomers { get; set; }
        public virtual DbSet<OdometerRecord> OdometerRecords { get; set; }
        public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PetroStation> PetroStations { get; set; }
        public virtual DbSet<PetrolCompany> PetrolCompanies { get; set; }
        public virtual DbSet<PetrolPrice> PetrolPrices { get; set; }
        public virtual DbSet<PetropayAccount> PetropayAccounts { get; set; }
        public virtual DbSet<PromotionCoupon> PromotionCoupons { get; set; }
        public virtual DbSet<RechargeBalance> RechargeBalances { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<ServiceMaster> ServiceMasters { get; set; }
        public virtual DbSet<StationUser> StationUsers { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<TransAccount> TransAccounts { get; set; }
        public virtual DbSet<ViewAccountBalance> ViewAccountBalances { get; set; }
        public virtual DbSet<ViewCarBalance> ViewCarBalances { get; set; }
        public virtual DbSet<ViewCarConsumptionRate> ViewCarConsumptionRates { get; set; }
        public virtual DbSet<ViewCarKmConsumption> ViewCarKmConsumptions { get; set; }
        public virtual DbSet<ViewCarOdometerMax> ViewCarOdometerMaxes { get; set; }
        public virtual DbSet<ViewCarOdometerMin> ViewCarOdometerMins { get; set; }
        public virtual DbSet<ViewCarTransaction> ViewCarTransactions { get; set; }
        public virtual DbSet<ViewCompanyBranchStatement> ViewCompanyBranchStatements { get; set; }
        public virtual DbSet<ViewCustomerBalance> ViewCustomerBalances { get; set; }
        public virtual DbSet<ViewCustomerStatement> ViewCustomerStatements { get; set; }
        public virtual DbSet<ViewInvoice> ViewInvoices { get; set; }
        public virtual DbSet<ViewInvoiceDetail> ViewInvoiceDetails { get; set; }
        public virtual DbSet<ViewInvoicesSummary> ViewInvoicesSummaries { get; set; }
        public virtual DbSet<ViewOdometerBetweenDate> ViewOdometerBetweenDates { get; set; }
        public virtual DbSet<ViewOdometerBetweenDateTemp> ViewOdometerBetweenDateTemps { get; set; }
        public virtual DbSet<ViewOdometerHistory> ViewOdometerHistories { get; set; }
        public virtual DbSet<ViewOdometerRecord> ViewOdometerRecords { get; set; }
        public virtual DbSet<ViewPetrolStationList> ViewPetrolStationLists { get; set; }
        public virtual DbSet<ViewStationBalance> ViewStationBalances { get; set; }
        public virtual DbSet<ViewStationReport> ViewStationReports { get; set; }
        public virtual DbSet<ViewStationSale> ViewStationSales { get; set; }
        public virtual DbSet<ViewStationStatement> ViewStationStatements { get; set; }

        public async Task ExecuteTransactionAsync(Func<Task> action)
        {
            await Database.BeginTransactionAsync();

            await action();

            try
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            catch
            {
                await Database.CurrentTransaction.RollbackAsync();

                throw;
            }
        }

        public async Task<T> ExecuteTransactionAsync<T>(Func<Task<T>> action)
        {
            await Database.BeginTransactionAsync();

            var result = await action();

            try
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            catch
            {
                await Database.CurrentTransaction.RollbackAsync();

                throw;
            }

            return result;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountMaster>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK_AccountMaster1");

                entity.ToTable("AccountMaster");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Name")
                    .IsFixedLength();

                entity.Property(e => e.AccountReference)
                    .HasMaxLength(25)
                    .HasColumnName("Account_reference")
                    .IsFixedLength();

                entity.Property(e => e.AccountTaype)
                    .HasMaxLength(30)
                    .HasColumnName("Account_taype")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Apidatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APIdata");

                entity.Property(e => e.ApiUrl).HasMaxLength(50);

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .HasColumnName("language");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .HasColumnName("message");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Sender)
                    .HasMaxLength(50)
                    .HasColumnName("sender");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<AppSetting>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("App_setting");

                entity.Property(e => e.BonusMoneyRate).HasColumnName("bonus_money_rate");

                entity.Property(e => e.ComapnyPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("comapny_phone_number");

                entity.Property(e => e.ComapnyTaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("comapny_tax_Rate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ComapnyTaxRecordNumber)
                    .HasMaxLength(50)
                    .HasColumnName("comapny_tax_record_number");

                entity.Property(e => e.ComapnyWebSite)
                    .HasMaxLength(50)
                    .HasColumnName("comapny_webSite");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(50)
                    .HasColumnName("company_address");

                entity.Property(e => e.CompanyCommercialRecordNumber)
                    .HasMaxLength(50)
                    .HasColumnName("company_commercial_record_number");

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(50)
                    .HasColumnName("company_email");

                entity.Property(e => e.CompanyLogo)
                    .IsUnicode(false)
                    .HasColumnName("company_logo");

                entity.Property(e => e.CompanyNameAr)
                    .HasMaxLength(50)
                    .HasColumnName("company_name_ar");

                entity.Property(e => e.CompanyNameEn)
                    .HasMaxLength(50)
                    .HasColumnName("company_name_en");

                entity.Property(e => e.CompanyStampImage)
                    .IsUnicode(false)
                    .HasColumnName("company_stamp_image");

                entity.Property(e => e.CompanyVatRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("company_Vat_rate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyVatTaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("company_Vat_tax_number");
            });

            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.HasKey(e => e.BundlesId)
                    .HasName("bundles$PrimaryKey");

                entity.HasIndex(e => e.BundlesId, "bundles$bundles_id");

                entity.Property(e => e.BundlesId)
                    .ValueGeneratedNever()
                    .HasColumnName("bundles_id");

                entity.Property(e => e.BundlesFeesMonthly)
                    .HasColumnType("money")
                    .HasColumnName("bundles_fees_monthly")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BundlesFeesYearly)
                    .HasColumnType("money")
                    .HasColumnName("bundles_fees_yearly")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BundlesNfcCost)
                    .HasColumnType("money")
                    .HasColumnName("bundles_nfc_cost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BundlesNumberFrom)
                    .HasColumnName("bundles_number_from")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BundlesNumberTo)
                    .HasColumnName("bundles_number_to")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.HasIndex(e => e.CarDriverConfirmationCode, "car$Car_driver_confirmation_code");

                entity.HasIndex(e => e.CompanyBarnchId, "car$c_barnch_id");

                entity.HasIndex(e => e.CarId, "car$car_id");

                entity.HasIndex(e => e.ConsumptionType, "car$carconsumption_id");

                entity.HasIndex(e => e.CompanyBarnchId, "car$company_branchcar");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.CarApprovedOneTime).HasColumnName("car_approved_one_time");

                entity.Property(e => e.CarBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("car_balnce")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CarBrand)
                    .HasMaxLength(255)
                    .HasColumnName("car_brand");

                entity.Property(e => e.CarChangeOliApproval).HasColumnName("car_change_oli_approval");

                entity.Property(e => e.CarChangeTyerApproval).HasColumnName("car_change_tyer_approval");

                entity.Property(e => e.CarDriverActive)
                    .HasColumnName("car_driver_active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CarDriverConfirmationCode)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_confirmation_code");

                entity.Property(e => e.CarDriverEmail)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_email");

                entity.Property(e => e.CarDriverName)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_name");

                entity.Property(e => e.CarDriverPassword)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_password");

                entity.Property(e => e.CarDriverPhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_phone_number");

                entity.Property(e => e.CarDriverUserName)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_user_name");

                entity.Property(e => e.CarFuelKmCap)
                    .HasColumnName("car_fuel_km_cap")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CarIdNumber1E)
                    .HasMaxLength(8)
                    .HasColumnName("car_id_number1_e");

                entity.Property(e => e.CarIdText1A)
                    .HasMaxLength(6)
                    .HasColumnName("car_id_text1_a");

                entity.Property(e => e.CarIdText1E)
                    .HasMaxLength(6)
                    .HasColumnName("car_id_text1_e");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(255)
                    .HasColumnName("car_model");

                entity.Property(e => e.CarModelYear)
                    .HasColumnName("car_model_year")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CarNeedPlatePhoto)
                    .HasColumnName("car_need_plate_photo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CarNfcCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("car_nfc_code")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength();

                entity.Property(e => e.CarOdometerRecordRequired)
                    .HasColumnName("car_odometer_record_required")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CarPlatePhoto).HasColumnName("car_plate_photo");

                entity.Property(e => e.CarType)
                    .HasMaxLength(255)
                    .HasColumnName("car_type")
                    .HasComment("sedain- truck");

                entity.Property(e => e.CarTypeOfFuel)
                    .HasMaxLength(255)
                    .HasColumnName("car_type_of_fuel");

                entity.Property(e => e.CarWashApproval).HasColumnName("car_wash_approval");

                entity.Property(e => e.CarWorkWithApproval).HasColumnName("car_work_with_approval");

                entity.Property(e => e.CompanyBarnchId)
                    .HasColumnName("company_barnch_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsumptionMethod)
                    .HasMaxLength(255)
                    .HasColumnName("consumption_method");

                entity.Property(e => e.ConsumptionType)
                    .HasMaxLength(255)
                    .HasColumnName("consumption_Type");

                entity.Property(e => e.ConsumptionValue)
                    .HasColumnType("money")
                    .HasColumnName("consumption_value")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Friday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Monday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Saturday).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.Sunday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Thursday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tuesday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Wednesday).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkAllDays).HasColumnName("work_all_days");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Car_AccountMaster");

                entity.HasOne(d => d.CompanyBarnch)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CompanyBarnchId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("car$company_branchcar");
            });

            modelBuilder.Entity<CarBrandMaster>(entity =>
            {
                entity.HasKey(e => e.CarBrandId);

                entity.ToTable("Car_brand_master");

                entity.Property(e => e.CarBrandId).HasColumnName("car_brand_id");

                entity.Property(e => e.CarBrandArName)
                    .HasMaxLength(50)
                    .HasColumnName("car_brand_ar_name");

                entity.Property(e => e.CarBrandEnName)
                    .HasMaxLength(50)
                    .HasColumnName("car_brand_en_name");
            });

            modelBuilder.Entity<CarModelMaster>(entity =>
            {
                entity.HasKey(e => e.CarModelId);

                entity.ToTable("Car_model_master");

                entity.Property(e => e.CarModelId).HasColumnName("car_model_id");

                entity.Property(e => e.CarBrandId).HasColumnName("car_brand_id");

                entity.Property(e => e.CarModelArName)
                    .HasMaxLength(50)
                    .HasColumnName("car_model_Ar_name");

                entity.Property(e => e.CarModelEnName)
                    .HasMaxLength(50)
                    .HasColumnName("car_model_En_name");

                entity.HasOne(d => d.CarBrand)
                    .WithMany(p => p.CarModelMasters)
                    .HasForeignKey(d => d.CarBrandId)
                    .HasConstraintName("FK_Car_model_master_Car_brand_master");
            });

            modelBuilder.Entity<CarSubscription>(entity =>
            {
                entity.HasKey(e => new { e.SubscriptionId, e.CarId })
                    .HasName("PK_car_subscription");

                entity.ToTable("CarSubscription");

                entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.Invoiced).HasColumnName("invoiced");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarSubscriptions)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_car_subscription_Car");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.CarSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_car_subscription_subscription");
            });

            modelBuilder.Entity<CarTypeMaster>(entity =>
            {
                entity.HasKey(e => e.CarTypeId)
                    .HasName("PK_car_type_master");

                entity.ToTable("Car_type_master");

                entity.Property(e => e.CarTypeId).HasColumnName("car_type_id");

                entity.Property(e => e.CarBonusPoint).HasColumnName("car_bonus_point");

                entity.Property(e => e.CarTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("car_type_name");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Company_address");

                entity.Property(e => e.CompanyAdminEmail)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_email");

                entity.Property(e => e.CompanyAdminName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_name");

                entity.Property(e => e.CompanyAdminPhone)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_phone");

                entity.Property(e => e.CompanyAdminPosition)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_position");

                entity.Property(e => e.CompanyAdminUserName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_user_name");

                entity.Property(e => e.CompanyAdminUserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("Company_admin_user_password");

                entity.Property(e => e.CompanyBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Company_balnce")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyCommercialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Company_commercial_number");

                entity.Property(e => e.CompanyCommercialPhoto).HasColumnName("Company_commercial_photo");

                entity.Property(e => e.CompanyCountry)
                    .HasMaxLength(255)
                    .HasColumnName("Company_country");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.CompanyRegion)
                    .HasMaxLength(255)
                    .HasColumnName("Company_Region");

                entity.Property(e => e.CompanyTaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Company_Tax_Number");

                entity.Property(e => e.CompanyTaxPhoto).HasColumnName("Company_Tax_photo");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(255)
                    .HasColumnName("Company_type");

                entity.Property(e => e.CompanyVatNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Company_VAT_Number");

                entity.Property(e => e.CompanyVatPhoto).HasColumnName("Company_VAT_photo");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Company_AccountMaster");
            });

            modelBuilder.Entity<CompanyBranch>(entity =>
            {
                entity.ToTable("Company_branch");

                entity.HasIndex(e => e.CompanyBranchId, "company_branch$C_branch_id");

                entity.HasIndex(e => e.CompanyId, "company_branch$Comp_id");

                entity.HasIndex(e => e.CompanyId, "company_branch$Companycompany_branch");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.CompanyBranchActiva)
                    .HasColumnName("company_branch_activa")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyBranchAddress)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_address");

                entity.Property(e => e.CompanyBranchAdminEmail)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_admin_email");

                entity.Property(e => e.CompanyBranchAdminName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_admin_name");

                entity.Property(e => e.CompanyBranchAdminPhone)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_admin_phone");

                entity.Property(e => e.CompanyBranchAdminUserName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_admin_user_name");

                entity.Property(e => e.CompanyBranchAdminUserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_admin_user_password");

                entity.Property(e => e.CompanyBranchBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("company_branch_balnce")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyBranchNumberOfcar)
                    .HasColumnName("company_branch_Number_ofcar")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CompanyBranches)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Company_branch_AccountMaster");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyBranches)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("company_branch$Companycompany_branch");
            });

            modelBuilder.Entity<EmployeeMenu>(entity =>
            {
                entity.ToTable("EmployeeMenu");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeMenus)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.EmployeeMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu");
            });

            modelBuilder.Entity<Emplyee>(entity =>
            {
                entity.ToTable("Emplyee");

                entity.HasIndex(e => e.EmplyeeCode, "Emplyee$Emplyee_code");

                entity.HasIndex(e => e.EmplyeeId, "Emplyee$Emplyee_id");

                entity.Property(e => e.EmplyeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Emplyee_id");

                entity.Property(e => e.EmplyeeCode)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_code");

                entity.Property(e => e.EmplyeeEmail)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_email");

                entity.Property(e => e.EmplyeeName)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_name");

                entity.Property(e => e.EmplyeePassword)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_password");

                entity.Property(e => e.EmplyeePhone)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_phone");

                entity.Property(e => e.EmplyeePhoto).HasColumnName("Emplyee_photo");

                entity.Property(e => e.EmplyeeStatus)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_status");

                entity.Property(e => e.EmplyeeUserName)
                    .HasMaxLength(255)
                    .HasColumnName("Emplyee_user_name");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.CarId, "invoice$carinvoice");

                entity.HasIndex(e => e.InvoiceConfirmedCode, "invoice$invoice_confirmed_code");

                entity.HasIndex(e => e.InvoiceId, "invoice$invoice_id");

                entity.HasIndex(e => e.StationId, "invoice$petro_stationinvoice");

                entity.HasIndex(e => e.StationId, "invoice$station_id");

                entity.HasIndex(e => e.StationUserId, "invoice$station_user_id");

                entity.HasIndex(e => e.StationUserId, "invoice$station_userinvoice");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.CarId)
                    .HasColumnName("car_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceAmount)
                    .HasColumnName("invoice_amount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceBonusPoints).HasColumnName("invoice_bonus_points");

                entity.Property(e => e.InvoiceConfirmedCode)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_confirmed_code");

                entity.Property(e => e.InvoiceDataTime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_data_time");

                entity.Property(e => e.InvoiceFuelConsumptionLiter)
                    .HasColumnName("invoice_fuel_consumption_liter")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceFuelLterPrice)
                    .HasColumnType("money")
                    .HasColumnName("invoice_fuel_lter_price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceFuelType)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_fuel_type")
                    .HasComment("90&92&kirosin");

                entity.Property(e => e.InvoiceNot)
                    .HasMaxLength(200)
                    .HasColumnName("invoice_not");

                entity.Property(e => e.InvoiceOdometer)
                    .HasColumnName("Invoice_odometer")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoicePayStatus)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_pay_status");

                entity.Property(e => e.InvoicePayType)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_pay_type")
                    .HasComment("cash&customer balnce");

                entity.Property(e => e.InvoicePayTypeId).HasColumnName("invoice_pay_type_id");

                entity.Property(e => e.InvoicePlatePhoto).HasColumnName("invoice_plate_photo");

                entity.Property(e => e.InvoicePumpPhoto).HasColumnName("invoice_pump_photo");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationUserId)
                    .HasColumnName("station_user_id")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("invoice$carinvoice");

                entity.HasOne(d => d.InvoicePayTypeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoicePayTypeId)
                    .HasConstraintName("invoicepaymentId_Payement_methodID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("Servicer_Id&ServiceMaster");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Invoice_Petro_station");

                entity.HasOne(d => d.StationUser)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StationUserId)
                    .HasConstraintName("FK_Invoice_Station_user");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.ArTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('NULL')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('NULL')");

                entity.Property(e => e.EnTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UrlRoute)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ParentMenu");
            });

            modelBuilder.Entity<NewCustomer>(entity =>
            {
                entity.HasKey(e => e.CustReqId);

                entity.ToTable("New_customer");

                entity.Property(e => e.CustReqId).HasColumnName("cust_req_id");

                entity.Property(e => e.CustAddress)
                    .HasMaxLength(50)
                    .HasColumnName("cust_address");

                entity.Property(e => e.CustCompany)
                    .HasMaxLength(50)
                    .HasColumnName("cust_company");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(50)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("cust_phone_number");

                entity.Property(e => e.CustReqStatus).HasColumnName("cust_req_status");

                entity.Property(e => e.CutReqDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("cut_req_datetime");
            });

            modelBuilder.Entity<OdometerRecord>(entity =>
            {
                entity.ToTable("Odometer_Record");

                entity.Property(e => e.OdometerRecordId).HasColumnName("odometerRecordID");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasColumnName("user_type");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.OdometerRecords)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Odometer_Record_Car");
            });

            modelBuilder.Entity<PasswordResetToken>(entity =>
            {
                entity.ToTable("PasswordResetToken");

                entity.Property(e => e.ResetRequestDate).HasColumnType("datetime");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("Payment_method");

                entity.Property(e => e.PaymentMethodId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_method_id");

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method_name");
            });

            modelBuilder.Entity<PetroStation>(entity =>
            {
                entity.HasKey(e => e.StationId)
                    .HasName("PK__Petro_st__44B370E9BEB87B8E");

                entity.ToTable("Petro_station");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.PetrolCompanyId).HasColumnName("Petrol_Company_id");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.StationAddress)
                    .HasMaxLength(255)
                    .HasColumnName("station_address");

                entity.Property(e => e.StationBalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("station_balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationBanckAccount)
                    .HasMaxLength(255)
                    .HasColumnName("station_banck_account");

                entity.Property(e => e.StationBonusBalance)
                    .HasColumnName("station_bonus_balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationCarWashingService).HasColumnName("station_car_washing_service");

                entity.Property(e => e.StationChangeOilService).HasColumnName("station_change_oil_service");

                entity.Property(e => e.StationChangeTireService).HasColumnName("station_change_tire_service");

                entity.Property(e => e.StationDiesel).HasColumnName("station_diesel");

                entity.Property(e => e.StationEmail)
                    .HasMaxLength(50)
                    .HasColumnName("station_email");

                entity.Property(e => e.StationLatitude)
                    .HasColumnName("station_latitude")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationLongitude)
                    .HasColumnName("station_longitude")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationLucationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_lucation_name");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_name");

                entity.Property(e => e.StationNameAr)
                    .HasMaxLength(100)
                    .HasColumnName("station_name_ar");

                entity.Property(e => e.StationOwnerName)
                    .HasMaxLength(255)
                    .HasColumnName("station_owner_name");

                entity.Property(e => e.StationPassword)
                    .HasMaxLength(255)
                    .HasColumnName("station_password");

                entity.Property(e => e.StationPhone)
                    .HasMaxLength(255)
                    .HasColumnName("station_phone");

                entity.Property(e => e.StationServiceActive).HasColumnName("station_service_active");

                entity.Property(e => e.StationServiceDeposit).HasColumnName("station_service_deposit");

                entity.Property(e => e.StationUserName)
                    .HasMaxLength(255)
                    .HasColumnName("station_user_name");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PetroStations)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Petro_station_AccountMaster");

                entity.HasOne(d => d.PetrolCompany)
                    .WithMany(p => p.PetroStations)
                    .HasForeignKey(d => d.PetrolCompanyId)
                    .HasConstraintName("FK_Petro_station_Petrol_Company");
            });

            modelBuilder.Entity<PetrolCompany>(entity =>
            {
                entity.ToTable("Petrol_Company");

                entity.Property(e => e.PetrolCompanyId).HasColumnName("Petrol_Company_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.PetrolCompanyAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_address");

                entity.Property(e => e.PetrolCompanyAdminEmail)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_email");

                entity.Property(e => e.PetrolCompanyAdminName)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_name");

                entity.Property(e => e.PetrolCompanyAdminPhone)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_phone");

                entity.Property(e => e.PetrolCompanyAdminPosition)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_position");

                entity.Property(e => e.PetrolCompanyAdminUserName)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_user_name");

                entity.Property(e => e.PetrolCompanyAdminUserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_admin_user_password");

                entity.Property(e => e.PetrolCompanyBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Petrol_Company_balnce");

                entity.Property(e => e.PetrolCompanyCommercialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_commercial_number");

                entity.Property(e => e.PetrolCompanyCommercialPhoto).HasColumnName("Petrol_Company_commercial_photo");

                entity.Property(e => e.PetrolCompanyCountry)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_country");

                entity.Property(e => e.PetrolCompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_name");

                entity.Property(e => e.PetrolCompanyRegion)
                    .HasMaxLength(255)
                    .HasColumnName("Petrol_Company_Region");

                entity.Property(e => e.PetrolCompanyTaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Petrol_Company_Tax_Number");

                entity.Property(e => e.PetrolCompanyTaxPhoto).HasColumnName("Petrol_Company_Tax_photo");

                entity.Property(e => e.PetrolCompanyVatNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Petrol_Company_VAT_Number");

                entity.Property(e => e.PetrolCompanyVatPhoto).HasColumnName("Petrol_Company_VAT_photo");
            });

            modelBuilder.Entity<PetrolPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PetrolPrice");

                entity.Property(e => e.PetrolPrice1).HasColumnName("PetrolPrice");

                entity.Property(e => e.PetrolPriceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PetrolPriceID");

                entity.Property(e => e.PetrolPriceType).HasMaxLength(50);
            });

            modelBuilder.Entity<PetropayAccount>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.ToTable("PetropayAccount");

                entity.Property(e => e.AccId).HasColumnName("Acc_ID");

                entity.Property(e => e.AccBalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Acc_Balance");

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .HasColumnName("Acc_Name");

                entity.Property(e => e.AccNot)
                    .HasMaxLength(50)
                    .HasColumnName("Acc_not");

                entity.Property(e => e.AccPaymentMethodShow).HasColumnName("Acc_paymentMethodShow");

                entity.Property(e => e.AccPetrolStationBonus).HasColumnName("Acc_petrol_Station_bonus");

                entity.Property(e => e.AccRefer)
                    .HasMaxLength(20)
                    .HasColumnName("Acc_refer")
                    .IsFixedLength();

                entity.Property(e => e.AccSubscriptionRequst).HasColumnName("Acc_SubscriptionRequst");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PetropayAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_PetropayAccount_AccountMaster");
            });

            modelBuilder.Entity<PromotionCoupon>(entity =>
            {
                entity.HasKey(e => e.CouponId)
                    .HasName("PK__promotio__58CF6389B37E60A9");

                entity.ToTable("promotion_Coupon");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CouponActive).HasColumnName("coupon_active");

                entity.Property(e => e.CouponActiveDate)
                    .HasColumnType("date")
                    .HasColumnName("coupon_active_date");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(10)
                    .HasColumnName("coupon_code")
                    .IsFixedLength();

                entity.Property(e => e.CouponDiscountValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("coupon_discount_value");

                entity.Property(e => e.CouponEndDate)
                    .HasColumnType("date")
                    .HasColumnName("coupon_end_date");

                entity.Property(e => e.CouponForAllCustomer).HasColumnName("coupon_for_all_customer");

                entity.Property(e => e.CouponForMonthly).HasColumnName("coupon_for_monthly");

                entity.Property(e => e.CouponForQuarterly).HasColumnName("coupon_for_Quarterly");

                entity.Property(e => e.CouponForYearly).HasColumnName("coupon_for_yearly");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<RechargeBalance>(entity =>
            {
                entity.HasKey(e => e.RechargeId);

                entity.ToTable("RechargeBalance");

                entity.Property(e => e.RechargeId).HasColumnName("Recharge_id");

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BankTransactionDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.RechageDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Rechage_Date");

                entity.Property(e => e.RechargeAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RechargePaymentMethod).HasMaxLength(50);

                entity.Property(e => e.TransactionPersonName).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RechargeBalances)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_RechargeBalance_Company");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpiresAt).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceMaster>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("ServiceMaster");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.ServiceArDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_Ar_Description");

                entity.Property(e => e.ServiceEnDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_En_Description");

                entity.Property(e => e.ServiceNote)
                    .HasMaxLength(250)
                    .HasColumnName("Service_note");

                entity.Property(e => e.ServiceTaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Service_Tax_Rate");
            });

            modelBuilder.Entity<StationUser>(entity =>
            {
                entity.HasKey(e => e.StationWorkerId);

                entity.ToTable("Station_user");

                entity.HasIndex(e => e.StationId, "station_user$petro_stationstation_user");

                entity.HasIndex(e => e.StationId, "station_user$station_id");

                entity.HasIndex(e => e.StationUserName, "station_user$station_user_code");

                entity.Property(e => e.StationWorkerId).HasColumnName("stationWorkerID");

                entity.Property(e => e.AccessAppReport).HasColumnName("access_AppReport");

                entity.Property(e => e.AccessBonusTransfer).HasColumnName("access_BonusTransfer");

                entity.Property(e => e.AccessCarWasherApp).HasColumnName("access_CarWasherApp");

                entity.Property(e => e.AccessChangeOilApp).HasColumnName("access_ChangeOilApp");

                entity.Property(e => e.AccessChangeTyreApp).HasColumnName("access_ChangeTyreApp");

                entity.Property(e => e.AccessFuelingApp).HasColumnName("access_FuelingApp");

                entity.Property(e => e.AccessStationBalance).HasColumnName("access_StationBalance");

                entity.Property(e => e.AccessStationBonusBalance).HasColumnName("access_stationBonusBalance");

                entity.Property(e => e.AccessTemp1).HasColumnName("access_temp1");

                entity.Property(e => e.AccessTemp2).HasColumnName("access_temp2");

                entity.Property(e => e.AccessTemp3).HasColumnName("access_temp3");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StationUserName)
                    .HasMaxLength(255)
                    .HasColumnName("stationUserName");

                entity.Property(e => e.StationUserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("stationUserPassword");

                entity.Property(e => e.StationWorkerFname)
                    .HasMaxLength(255)
                    .HasColumnName("stationWorkerFname");

                entity.Property(e => e.StationWorkerPhone)
                    .HasMaxLength(255)
                    .HasColumnName("stationWorkerPhone");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationUsers)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Station_user_Petro_station");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.HasIndex(e => e.CompanyId, "subscription$Companysubscription");

                entity.HasIndex(e => e.CompanyId, "subscription$ompany_id");

                entity.HasIndex(e => e.SubscriptionId, "subscription$subscription_id");

                entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");

                entity.Property(e => e.BundlesId).HasColumnName("bundles_id");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(10)
                    .HasColumnName("coupon_code")
                    .IsFixedLength();

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.NumberOfDateDiff)
                    .HasColumnName("numberOfDateDiff")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentReferenceNumber)
                    .HasMaxLength(50)
                    .HasColumnName("payment_reference_number");

                entity.Property(e => e.Rejected).HasColumnName("rejected");

                entity.Property(e => e.SubscriptionActive).HasColumnName("Subscription_active");

                entity.Property(e => e.SubscriptionCarNumbers)
                    .HasColumnName("subscription_car_numbers")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubscriptionCost)
                    .HasColumnType("money")
                    .HasColumnName("subscription_cost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubscriptionDate).HasColumnName("subscription_date");

                entity.Property(e => e.SubscriptionDiscountValues)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subscription_discount_values");

                entity.Property(e => e.SubscriptionEndDate).HasColumnName("subscription_end_date");

                entity.Property(e => e.SubscriptionInvoiceNumber).HasColumnName("subscription_invoice_number");

                entity.Property(e => e.SubscriptionPaymentDocPhoto).HasColumnName("subscription_payment_doc_photo");

                entity.Property(e => e.SubscriptionPaymentMethod)
                    .HasMaxLength(255)
                    .HasColumnName("subscription_payment_method");

                entity.Property(e => e.SubscriptionStartDate)
                    .HasPrecision(0)
                    .HasColumnName("subscription_start_date");

                entity.Property(e => e.SubscriptionTaxValue)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subscription_tax_value");

                entity.Property(e => e.SubscriptionType)
                    .HasMaxLength(255)
                    .HasColumnName("subscription_type")
                    .HasComment("monthly yearly quartly");

                entity.Property(e => e.SubscriptionVatTaxValue)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subscription_vat_tax_value");

                entity.HasOne(d => d.Bundles)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.BundlesId)
                    .HasConstraintName("FK_Subscription_Bundles");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("subscription$Companysubscription");
            });

            modelBuilder.Entity<TransAccount>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK_Transaction_1");

                entity.ToTable("TransAccount");

                entity.Property(e => e.TransId).HasColumnName("trans_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.TransAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trans_amount");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date");

                entity.Property(e => e.TransDocument)
                    .HasMaxLength(50)
                    .HasColumnName("trans_document")
                    .IsFixedLength();

                entity.Property(e => e.TransReference)
                    .HasMaxLength(50)
                    .HasColumnName("trans_reference")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasColumnName("user_type");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TransAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Transaction_AccountMaster");
            });

            modelBuilder.Entity<ViewAccountBalance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_AccountBalance");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Name")
                    .IsFixedLength();

                entity.Property(e => e.AccountTaype)
                    .HasMaxLength(30)
                    .HasColumnName("Account_taype")
                    .IsFixedLength();

                entity.Property(e => e.SumTransAmount)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_trans_amount");
            });

            modelBuilder.Entity<ViewCarBalance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CarBalance");

                entity.Property(e => e.CarBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("car_balnce");

                entity.Property(e => e.CarDriverName)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_name");

                entity.Property(e => e.CarFuelKmCap).HasColumnName("car_fuel_km_cap");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.ConsumptionValue)
                    .HasColumnType("money")
                    .HasColumnName("consumption_value");

                entity.Property(e => e.SubscriptionEndDate).HasColumnName("subscription_end_date");

                entity.Property(e => e.SubscriptionStartDate)
                    .HasPrecision(0)
                    .HasColumnName("subscription_start_date");
            });

            modelBuilder.Entity<ViewCarConsumptionRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_car_consumption_rate");

                entity.Property(e => e.AmountConsumption).HasColumnName("amount_consumption");

                entity.Property(e => e.CarDriverName)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_name");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CunsumptionRate).HasColumnName("cunsumption_rate");

                entity.Property(e => e.DateMax)
                    .HasColumnType("date")
                    .HasColumnName("date_max");

                entity.Property(e => e.DateMin)
                    .HasColumnType("date")
                    .HasColumnName("date_min");

                entity.Property(e => e.KmConsumption).HasColumnName("km_consumption");

                entity.Property(e => e.LiterConsumption).HasColumnName("liter_consumption");
            });

            modelBuilder.Entity<ViewCarKmConsumption>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_car_Km_consumption");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarOdometerConsumption).HasColumnName("car_odometer_consumption");

                entity.Property(e => e.DateMax)
                    .HasColumnType("date")
                    .HasColumnName("date_max");

                entity.Property(e => e.DateMin)
                    .HasColumnType("date")
                    .HasColumnName("date_min");

                entity.Property(e => e.OdometerValueMax).HasColumnName("odometer_value_max");

                entity.Property(e => e.OdometerValueMin).HasColumnName("odometer_value_min");
            });

            modelBuilder.Entity<ViewCarOdometerMax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_car_odometer_Max");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");
            });

            modelBuilder.Entity<ViewCarOdometerMin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_car_odometer_Min");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");
            });

            modelBuilder.Entity<ViewCarTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CarTransaction");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.TransAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trans_amount");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date");

                entity.Property(e => e.TransDocument)
                    .HasMaxLength(10)
                    .HasColumnName("trans_document")
                    .IsFixedLength();

                entity.Property(e => e.TransId).HasColumnName("trans_id");

                entity.Property(e => e.TransReference)
                    .HasMaxLength(10)
                    .HasColumnName("trans_reference")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ViewCompanyBranchStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_company_branch_statement");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.SumTransAmount)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_trans_amount");

                entity.Property(e => e.TransDocument)
                    .HasMaxLength(50)
                    .HasColumnName("trans_document")
                    .IsFixedLength();

                entity.Property(e => e.TransactionDateTime)
                    .HasMaxLength(4000)
                    .HasColumnName("transaction_date_time");
            });

            modelBuilder.Entity<ViewCustomerBalance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CustomerBalance");

                entity.Property(e => e.CompanyBalnce)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Company_balnce");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.NumberOfCars).HasColumnName("numberOfCars");

                entity.Property(e => e.SumCarBalnce)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_car_balnce");

                entity.Property(e => e.SumCompanyBranchBalnce)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_company_branch_balnce");
            });

            modelBuilder.Entity<ViewCustomerStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Customer_statement");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Name")
                    .IsFixedLength();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.SumTransAmount)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_trans_amount");

                entity.Property(e => e.TransDocument)
                    .HasMaxLength(50)
                    .HasColumnName("trans_document")
                    .IsFixedLength();

                entity.Property(e => e.TransactionDataTime)
                    .HasMaxLength(4000)
                    .HasColumnName("transaction_data_time");
            });

            modelBuilder.Entity<ViewInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Invoice");

                entity.Property(e => e.Amount)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddress).HasMaxLength(50);

                entity.Property(e => e.CompanyCommercialRecordNumber).HasMaxLength(50);

                entity.Property(e => e.CompanyEmail).HasMaxLength(50);

                entity.Property(e => e.CompanyLogo).IsUnicode(false);

                entity.Property(e => e.CompanyNameAr).HasMaxLength(50);

                entity.Property(e => e.CompanyNameEn).HasMaxLength(50);

                entity.Property(e => e.CompanyTaxRecordNumber).HasMaxLength(50);

                entity.Property(e => e.CompanyWebsite).HasMaxLength(50);

                entity.Property(e => e.CustomerAddress).HasMaxLength(255);

                entity.Property(e => e.CustomerName).HasMaxLength(255);

                entity.Property(e => e.Discount)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceEndDate).HasColumnType("date");

                entity.Property(e => e.ServiceStartDate).HasColumnType("date");

                entity.Property(e => e.SubTotal)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UnitCost)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Vat)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VatRate)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewInvoiceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Invoice_Details");

                entity.Property(e => e.InvoiceDataTime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_data_time");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.InvoicePayStatus)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_pay_status");

                entity.Property(e => e.InvoicePayType)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_pay_type");

                entity.Property(e => e.InvoicePlatePhoto).HasColumnName("invoice_plate_photo");

                entity.Property(e => e.InvoicePumpPhoto).HasColumnName("invoice_pump_photo");

                entity.Property(e => e.ServiceArDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_Ar_Description");

                entity.Property(e => e.ServiceEnDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_En_Description");

                entity.Property(e => e.StationLatitude).HasColumnName("station_latitude");

                entity.Property(e => e.StationLongitude).HasColumnName("station_longitude");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_name");

                entity.Property(e => e.StationNameAr)
                    .HasMaxLength(100)
                    .HasColumnName("station_name_ar");
            });

            modelBuilder.Entity<ViewInvoicesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Invoices_summary");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.InvoiceAmount).HasColumnName("invoice_amount");

                entity.Property(e => e.InvoiceDataTime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_data_time");

                entity.Property(e => e.InvoiceFuelConsumptionLiter).HasColumnName("invoice_fuel_consumption_liter");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method_name");

                entity.Property(e => e.ServiceArDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_Ar_Description");

                entity.Property(e => e.ServiceEnDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_En_Description");
            });

            modelBuilder.Entity<ViewOdometerBetweenDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_odometer_between_date");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerRecordId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("odometerRecordID");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");
            });

            modelBuilder.Entity<ViewOdometerBetweenDateTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("View_odometer_between_date_temp");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerRecordId).HasColumnName("odometerRecordID");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");
            });

            modelBuilder.Entity<ViewOdometerHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_odometer_history");

                entity.Property(e => e.CarDriverName)
                    .HasMaxLength(255)
                    .HasColumnName("car_driver_name");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CarTypeOfFuel)
                    .HasMaxLength(255)
                    .HasColumnName("car_type_of_fuel");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");
            });

            modelBuilder.Entity<ViewOdometerRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Odometer_Record");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.CompanyBranchId).HasColumnName("company_branch_id");

                entity.Property(e => e.CompanyBranchName)
                    .HasMaxLength(255)
                    .HasColumnName("company_branch_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_name");

                entity.Property(e => e.OdometerRecordDate)
                    .HasColumnType("date")
                    .HasColumnName("odometer_record_date");

                entity.Property(e => e.OdometerRecordId).HasColumnName("odometerRecordID");

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");

                entity.Property(e => e.Seqnum).HasColumnName("seqnum");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<ViewPetrolStationList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Petrol_Station_list");

                entity.Property(e => e.StationDiesel).HasColumnName("station_diesel");

                entity.Property(e => e.StationLatitude).HasColumnName("station_latitude");

                entity.Property(e => e.StationLongitude).HasColumnName("station_longitude");

                entity.Property(e => e.StationLucationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_lucation_name");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_name");

                entity.Property(e => e.StationNameAr)
                    .HasMaxLength(100)
                    .HasColumnName("station_name_ar");
            });

            modelBuilder.Entity<ViewStationBalance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_StationBalance");

                entity.Property(e => e.StationAddress)
                    .HasMaxLength(255)
                    .HasColumnName("station_address");

                entity.Property(e => e.StationBalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("station_balance");

                entity.Property(e => e.StationBanckAccount)
                    .HasMaxLength(255)
                    .HasColumnName("station_banck_account");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.StationLucationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_lucation_name");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_name");

                entity.Property(e => e.StationOwnerName)
                    .HasMaxLength(255)
                    .HasColumnName("station_owner_name");
            });

            modelBuilder.Entity<ViewStationReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_StationReport");

                entity.Property(e => e.CarIdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_id_number");

                entity.Property(e => e.InvoiceAmount).HasColumnName("invoice_amount");

                entity.Property(e => e.InvoiceDataTime)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_data_time");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method_name");

                entity.Property(e => e.ServiceArDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Service_Ar_Description");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.StationWorkerFname)
                    .HasMaxLength(255)
                    .HasColumnName("stationWorkerFname");

                entity.Property(e => e.StationWorkerId).HasColumnName("stationWorkerID");
            });

            modelBuilder.Entity<ViewStationSale>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_StationSales");

                entity.Property(e => e.InvoiceFuelType)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_fuel_type");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.StationWorkerFname)
                    .HasMaxLength(255)
                    .HasColumnName("stationWorkerFname");

                entity.Property(e => e.StationWorkerId).HasColumnName("stationWorkerID");

                entity.Property(e => e.SumInvoiceAmount).HasColumnName("Sum_invoice_amount");

                entity.Property(e => e.SumInvoiceBonusPoints).HasColumnName("sum_InvoiceBonusPoints");

                entity.Property(e => e.SumInvoiceDataTime)
                    .HasMaxLength(4000)
                    .HasColumnName("Sum_invoice_data_time");

                entity.Property(e => e.SumInvoiceFuelConsumptionLiter).HasColumnName("Sum_invoice_fuel_consumption_liter");
            });

            modelBuilder.Entity<ViewStationStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_StationStatement");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Name")
                    .IsFixedLength();

                entity.Property(e => e.InvoiceDataTime)
                    .HasMaxLength(4000)
                    .HasColumnName("invoice_data_time");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .HasColumnName("station_name");

                entity.Property(e => e.SumTransAmount)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("Sum_trans_amount");

                entity.Property(e => e.TransDocument)
                    .HasMaxLength(50)
                    .HasColumnName("trans_document")
                    .IsFixedLength();

                entity.Property(e => e.TransReference)
                    .HasMaxLength(50)
                    .HasColumnName("trans_reference")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
