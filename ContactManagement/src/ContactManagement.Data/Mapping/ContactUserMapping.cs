using ContactManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManagement.Data.Mapping
{
	public class ContactUserMapping : IEntityTypeConfiguration<ContactUser>
	{
		public void Configure(EntityTypeBuilder<ContactUser> builder)
		{
			builder.ToTable("ContactUser");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name);
			builder.Property(x => x.Contact);
			builder.Property(x => x.Email);
		}
	}
}