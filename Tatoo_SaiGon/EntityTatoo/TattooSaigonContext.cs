using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TattooSaigonContext : DbContext
{
    public TattooSaigonContext()
    {
    }

    public TattooSaigonContext(DbContextOptions<TattooSaigonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAddressStudio> TblAddressStudios { get; set; }

    public virtual DbSet<TblArtist> TblArtists { get; set; }

    public virtual DbSet<TblBooking> TblBookings { get; set; }

    public virtual DbSet<TblBookingDetail> TblBookingDetails { get; set; }

    public virtual DbSet<TblCertificate> TblCertificates { get; set; }

    public virtual DbSet<TblFeedback> TblFeedbacks { get; set; }

    public virtual DbSet<TblFeedbackSystem> TblFeedbackSystems { get; set; }

    public virtual DbSet<TblImageFeedback> TblImageFeedbacks { get; set; }

    public virtual DbSet<TblImageService> TblImageServices { get; set; }

    public virtual DbSet<TblInformationArtist> TblInformationArtists { get; set; }

    public virtual DbSet<TblJob> TblJobs { get; set; }

    public virtual DbSet<TblJobApplication> TblJobApplications { get; set; }

    public virtual DbSet<TblManagerStudio> TblManagerStudios { get; set; }

    public virtual DbSet<TblMember> TblMembers { get; set; }

    public virtual DbSet<TblPayment> TblPayments { get; set; }

    public virtual DbSet<TblReport> TblReports { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSalary> TblSalaries { get; set; }

    public virtual DbSet<TblSchedule> TblSchedules { get; set; }

    public virtual DbSet<TblService> TblServices { get; set; }

    public virtual DbSet<TblServiceItem> TblServiceItems { get; set; }

    public virtual DbSet<TblStudio> TblStudios { get; set; }

    public virtual DbSet<TblStudioStaff> TblStudioStaffs { get; set; }

    public virtual DbSet<TblSystemStaff> TblSystemStaffs { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    private string Getconnection()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var str = config["ConnectionStrings:Tatoo"];
        return str;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Getconnection());
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddressStudio>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__tbl_Addr__091C2A1B31ADA4A8");

            entity.ToTable("tbl_AddressStudio");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("AddressID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AddressDetail).HasMaxLength(200);
            entity.Property(e => e.Phonenumber).HasMaxLength(20);

            entity.HasOne(d => d.Studio).WithMany(p => p.TblAddressStudios)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_AddressStudio_Studio");
        });

        modelBuilder.Entity<TblArtist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__tbl_Arti__25706B7087F66DDD");

            entity.ToTable("tbl_Artist");

            entity.Property(e => e.ArtistId)
                .ValueGeneratedNever()
                .HasColumnName("ArtistID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__tbl_Book__73951ACD3B4DB089");

            entity.ToTable("tbl_Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.CreateBooking).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Note).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.TblBookings)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Member_Booking");

            entity.HasOne(d => d.Payment).WithMany(p => p.TblBookings)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Payment_Booking");
        });

        modelBuilder.Entity<TblBookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__tbl_Book__8136D47A6A75FCBE");

            entity.ToTable("tbl_BookingDetail");

            entity.Property(e => e.BookingDetailId)
                .ValueGeneratedNever()
                .HasColumnName("BookingDetailID");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Booking).WithMany(p => p.TblBookingDetails)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_BookingDetail_Booking");

            entity.HasOne(d => d.Service).WithMany(p => p.TblBookingDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Service_Booking");
        });

        modelBuilder.Entity<TblCertificate>(entity =>
        {
            entity.HasKey(e => e.CerId).HasName("PK__tbl_Cert__4C3D55D999CA3D1E");

            entity.ToTable("tbl_Certificate");

            entity.Property(e => e.CerId)
                .ValueGeneratedNever()
                .HasColumnName("CerID");
            entity.Property(e => e.InforId).HasColumnName("InforID");

            entity.HasOne(d => d.Infor).WithMany(p => p.TblCertificates)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("FK_Certificate_InformationArtist");
        });

        modelBuilder.Entity<TblFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__tbl_Feed__6A4BEDF690588CB3");

            entity.ToTable("tbl_Feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.IsFeedback).HasDefaultValueSql("((0))");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Member).WithMany(p => p.TblFeedbacks)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Feedback_Member");

            entity.HasOne(d => d.Service).WithMany(p => p.TblFeedbacks)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Feedback_Service");
        });

        modelBuilder.Entity<TblFeedbackSystem>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__tbl_Feed__6A4BEDF6B7C983F4");

            entity.ToTable("tbl_FeedbackSystem");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.FeedbackDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Manager).WithMany(p => p.TblFeedbackSystems)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_FeedbackSystem_ManagerStudio");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblFeedbackSystems)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_FeedbackSystem_StudioStaff");
        });

        modelBuilder.Entity<TblImageFeedback>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__tbl_Imag__7516F4EC192090A0");

            entity.ToTable("tbl_ImageFeedback");

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnName("ImageID");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

            entity.HasOne(d => d.Feedback).WithMany(p => p.TblImageFeedbacks)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK_ImageFeedback_Feedback");
        });

        modelBuilder.Entity<TblImageService>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__tbl_Imag__7516F4EC8814EF15");

            entity.ToTable("tbl_ImageService");

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnName("ImageID");
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Service).WithMany(p => p.TblImageServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_ImageService_Service");
        });

        modelBuilder.Entity<TblInformationArtist>(entity =>
        {
            entity.HasKey(e => e.InforId).HasName("PK__tbl_Info__1D605C7309A388D6");

            entity.ToTable("tbl_InformationArtist");

            entity.Property(e => e.InforId)
                .ValueGeneratedNever()
                .HasColumnName("InforID");
            entity.Property(e => e.Accommodation)
                .HasMaxLength(100)
                .HasColumnName("accommodation");
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CurrentAddress).HasMaxLength(100);
            entity.Property(e => e.Phonenumber).HasMaxLength(30);

            entity.HasOne(d => d.Artist).WithMany(p => p.TblInformationArtists)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_InformationArtist_Artist");
        });

        modelBuilder.Entity<TblJob>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__tbl_Jobs__056690E2401C6638");

            entity.ToTable("tbl_Jobs");

            entity.Property(e => e.JobId)
                .ValueGeneratedNever()
                .HasColumnName("JobID");
            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Artist).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_Jobs_Artist");
        });

        modelBuilder.Entity<TblJobApplication>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__tbl_JobA__164AA1A876653B8F");

            entity.ToTable("tbl_JobApplication");

            entity.Property(e => e.JobId)
                .ValueGeneratedNever()
                .HasColumnName("jobId");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Member).WithMany(p => p.TblJobApplications)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Member_Job");
        });

        modelBuilder.Entity<TblManagerStudio>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__tbl_Mana__3BA2AAE1A6B27B85");

            entity.ToTable("tbl_ManagerStudio");

            entity.Property(e => e.ManagerId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.ManagementName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblManagerStudios)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_ManagerStudio_SystemStaff");
        });

        modelBuilder.Entity<TblMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__tbl_Memb__0CF04B3825BC25F1");

            entity.ToTable("tbl_Member");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.CreateMember).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.MemberName).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);

            entity.HasOne(d => d.User).WithMany(p => p.TblMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Member");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__tbl_Paym__9B556A380D837331");

            entity.ToTable("tbl_Payment");

            entity.Property(e => e.PaymentId).ValueGeneratedNever();
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Method).HasMaxLength(30);
            entity.Property(e => e.PaymentBooking).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.TblPayments)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Member_Payment");
        });

        modelBuilder.Entity<TblReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__tbl_Repo__D5BD48E5B7038A08");

            entity.ToTable("tbl_Report");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("ReportID");
            entity.Property(e => e.CreateReport).HasColumnType("datetime");
            entity.Property(e => e.IsReport).HasDefaultValueSql("((0))");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Member).WithMany(p => p.TblReports)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Report_Member");

            entity.HasOne(d => d.Service).WithMany(p => p.TblReports)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Report_Service");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tbl_Role__8AFACE3A8DD24F1C");

            entity.ToTable("tbl_Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<TblSalary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__tbl_Sala__4BE204B72A25AD4B");

            entity.ToTable("tbl_Salary");

            entity.Property(e => e.SalaryId)
                .ValueGeneratedNever()
                .HasColumnName("SalaryID");
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(30);
            entity.Property(e => e.SalaryDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Artist).WithMany(p => p.TblSalaries)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_Salary_Artist");
        });

        modelBuilder.Entity<TblSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__tbl_Sche__9C8A5B693A712472");

            entity.ToTable("tbl_Schedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("ScheduleID");
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.Attendent).HasMaxLength(1);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FreeTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Artist).WithMany(p => p.TblSchedules)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_Schedule_Artist");
        });

        modelBuilder.Entity<TblService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__tbl_Serv__C51BB0EA4593F864");

            entity.ToTable("tbl_Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ServiceItemId)
                .HasMaxLength(100)
                .HasColumnName("ServiceItemID");
            entity.Property(e => e.ServiceName).HasMaxLength(100);

            entity.HasOne(d => d.Artist).WithMany(p => p.TblServices)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_Service_Artist");

            entity.HasOne(d => d.ServiceItem).WithMany(p => p.TblServices)
                .HasForeignKey(d => d.ServiceItemId)
                .HasConstraintName("FK_Service_ServiceItem");
        });

        modelBuilder.Entity<TblServiceItem>(entity =>
        {
            entity.HasKey(e => e.ServiceItemId).HasName("PK__tbl_Serv__CC153FD84BAA1395");

            entity.ToTable("tbl_ServiceItem");

            entity.Property(e => e.ServiceItemId)
                .HasMaxLength(100)
                .HasColumnName("ServiceItemID");
            entity.Property(e => e.ServiceName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblStudio>(entity =>
        {
            entity.HasKey(e => e.StudioId).HasName("PK__tbl_Stud__4ACC3B701BCF040A");

            entity.ToTable("tbl_Studio");

            entity.Property(e => e.StudioId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.StudioName).HasMaxLength(100);

            entity.HasOne(d => d.Manager).WithMany(p => p.TblStudios)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Studio_ManagerStudio");

            entity.HasOne(d => d.Service).WithMany(p => p.TblStudios)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Studio_Service");
        });

        modelBuilder.Entity<TblStudioStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__tbl_Stud__96D4AAF7705D866C");

            entity.ToTable("tbl_StudioStaff");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Studio).WithMany(p => p.TblStudioStaffs)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_StudioStaff_Studio");

            entity.HasOne(d => d.User).WithMany(p => p.TblStudioStaffs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_StudioStaff_User");
        });

        modelBuilder.Entity<TblSystemStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__tbl_Syst__96D4AAF7D3591EDB");

            entity.ToTable("tbl_SystemStaff");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.TblSystemStaffs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SystemStaff_User");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__1788CC4CD886B03F");

            entity.ToTable("tbl_User");

            entity.Property(e => e.CreateUser).HasColumnType("datetime");
            entity.Property(e => e.Dob).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(40);
            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasColumnName("RoleID");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Role_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
