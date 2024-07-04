using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories;
using Api.Models.Domain ; 
using Api.Data ; 


namespace Api.Repositories
{
    public class ImageRepository:IImageRepository
    {

        private readonly ServiceContext serviceContext ; 
        private readonly IWebHostEnvironment webHostEnvironment ; 
        private readonly IHttpContextAccessor httpContextAccessor ; 

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor , ServiceContext serviceContext)
        {
            this.serviceContext      = serviceContext ; 
            this.webHostEnvironment  = webHostEnvironment ; 
            this.httpContextAccessor = httpContextAccessor ; 
        }

        public async Task<Image> Upload(Image image)
        {

            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath , "Images" , $"{image.FileName}{image.FileExtension}") ;

            //upload image to local path
            using var stream = new FileStream(localFilePath , FileMode.Create) ;
            await image.File.CopyToAsync(stream) ;

            //http://localhost:5172/images
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}" ; 

            image.FilePath = urlFilePath ; 

            //add image to the Images table
            await serviceContext.Images.AddAsync(image) ;

            await serviceContext.SaveChangesAsync() ;

            return image ; 

        }

    }
}