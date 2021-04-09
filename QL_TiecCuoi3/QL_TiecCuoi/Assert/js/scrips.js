function ShowImage(imageUpload, previewImage)
{
    if (imageUpload.files && imageUpload.files[0])
    {
        var read = new FileReader();
        read.onload = function (e)
        {
            $(previewImage).attr('src', e.target.result);
        }
        read.readAsDataURL(imageUpload.files[0]);
    }
}
