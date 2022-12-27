﻿using Cropper.Blazor.Base;
using Cropper.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Cropper.Blazor.Services
{
    public interface ICropperJsInterop
    {
        /// <summary>
        /// Loads cropper JS module.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LoadModuleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Initializes cropper. 
        /// </summary>
        /// <param name="image">Reference to img html-DOM</param>
        /// <param name="options">Cropper options</param>
        /// <param name="cropperComponentBase">Reference to base cropper component. Default equal to 'this' object  </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask InitCropperAsync(
            [NotNull] ElementReference image,
            [NotNull] Options options,
            [NotNull] DotNetObjectReference<ICropperComponentBase> cropperComponentBase,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Clear the crop box.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ClearAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Show the crop box manually.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask CropAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Destroy the cropper and remove the instance from the image.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask DestroyAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Disable (freeze) the cropper.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask DisableAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Enable (unfreeze) the cropper.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask EnableAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the canvas position and size data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The result canvas data.</returns>
        ValueTask<CanvasData> GetCanvasDataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the container size data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The result container data.</returns>
        ValueTask<ContainerData> GetContainerDataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the crop box position and size data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The result crop box data.</returns>
        ValueTask<CropBoxData> GetCropBoxDataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the cropped area position and size data (base on the original image).
        /// </summary>
        /// <param name="rounded">Indicate if round the data values or not.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result cropped data.</returns>
        ValueTask<CropperData> GetDataAsync(
            bool rounded,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the image position and size data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The result image data.</returns>
        ValueTask<ImageData> GetImageDataAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Move the canvas with relative offsets.
        /// </summary>
        /// <param name="offsetX">The relative offset distance on the x-axis.</param>
        /// <param name="offsetY">The relative offset distance on the y-axis.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask MoveAsync(
            decimal offsetX,
            decimal? offsetY,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Move the canvas to an absolute point.
        /// </summary>
        /// <param name="x">The x-axis coordinate.</param>
        /// <param name="y">The y-axis coordinate.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask MoveToAsync(
            decimal x,
            decimal? y,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Replace the image's src and rebuild the cropper.
        /// </summary>
        /// <param name="url">The new URL.</param>
        /// <param name="onlyColorChanged">Indicate if the new image has the same size as the old one.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ReplaceAsync(
            string url,
            bool onlyColorChanged,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Reset the image and crop box to their initial states.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ResetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Rotate the canvas with a relative degree.
        /// </summary>
        /// <param name="degree">The rotate degree.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask RotateAsync(
            decimal degree,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Rotate the canvas to an absolute degree.
        /// </summary>
        /// <param name="degree">The rotate degree.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask RotateToAsync(
            decimal degree,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Scale the image.
        /// </summary>
        /// <param name="scaleX">The scale ratio on the x-axis.</param>
        /// <param name="scaleY">The scale ratio on the y-axis.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ScaleAsync(
            decimal scaleX,
            decimal scaleY,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Scale the image on the x-axis.
        /// </summary>
        /// <param name="scaleX">The scale ratio on the x-axis.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ScaleXAsync(
            decimal scaleX,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Scale the image on the y-axis.
        /// </summary>
        /// <param name="scaleY">The scale ratio on the y-axis.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ScaleYAsync(
            decimal scaleY,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the canvas position and size with new data.
        /// </summary>
        /// <param name="setCanvasDataOptions">The new canvas data.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetCanvasDataAsync(
            SetCanvasDataOptions setCanvasDataOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the crop box position and size with new data.
        /// </summary>
        /// <param name="cropBoxDataOptions">The new crop box data.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetCropBoxDataAsync(
            SetCropBoxDataOptions cropBoxDataOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the cropped area position and size with new data.
        /// </summary>
        /// <param name="setDataOptions">The new data.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetDataAsync(
            SetDataOptions setDataOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Change the drag mode.
        /// </summary>
        /// <param name="dragMode">The new drag mode.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetDragModeAsync(
            DragMode dragMode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Zoom the canvas with a relative ratio/
        /// </summary>
        /// <param name="ratio">The target ratio.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ZoomAsync(
            decimal ratio,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Zoom the canvas to an absolute ratio.
        /// </summary>
        /// <param name="ratio">The target ratio.</param>
        /// <param name="pivotX">The zoom pivot point X coordinate.</param>
        /// <param name="pivotY">The zoom pivot point Y coordinate.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask ZoomToAsync(
            decimal ratio,
            decimal pivotX,
            decimal pivotY,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the no conflict cropper class.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask NoConflictAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Change the default options.
        /// </summary>
        /// <param name="options">The new default options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetDefaultsAsync(
            [NotNull] Options options,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Change the aspect ratio of the crop box.
        /// </summary>
        /// <param name="aspectRatio">The new aspect ratio.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask SetAspectRatioAsync(
            decimal aspectRatio,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a canvas drawn the cropped image.
        /// </summary>
        /// <param name="getCroppedCanvasOptions">The config options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result canvas.</returns>
        ValueTask<object> GetCroppedCanvasAsync(
            GetCroppedCanvasOptions getCroppedCanvasOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a canvas drawn the cropped image.
        /// </summary>
        /// <param name="getCroppedCanvasOptions">The config options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result canvas.</returns>
        ValueTask<string> GetCroppedCanvasDataURLAsync(
            GetCroppedCanvasOptions getCroppedCanvasOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Used to get an image from a stream.
        /// <br/>
        /// Converts JavaScript stream to .NET stream uses <see cref="DotNetStreamReference"/>, and then creates a URL blob reference.
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="maxAllowedSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>URL blob reference.</returns>
        ValueTask<string> GetImageUsingStreamingAsync(
            IBrowserFile imageFile,
            long maxAllowedSize = 512000L,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Call this method when you've finished using an object URL to let the browser know not to keep the reference to the file any longer.
        /// </summary>
        /// <param name="url">A string representing an object URL.</param>
        /// <returns></returns>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask RevokeObjectUrlAsync(
            string url,
            CancellationToken cancellationToken = default);
    }
}