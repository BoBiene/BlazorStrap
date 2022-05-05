﻿using BlazorComponentUtilities;
using BlazorStrap.Service;
using BlazorStrap.Utilities;
using Microsoft.AspNetCore.Components;


namespace BlazorStrap
{
    public abstract class BlazorStrapBase : ComponentBase, IBlazorStrapBase
    {
        protected BlazorStrapCore BlazorStrap => (BlazorStrapCore)BlazorStrapSrc;
        // ReSharper disable once NullableWarningSuppressionIsUsed
        [Inject] public IBlazorStrap BlazorStrapSrc { get; set; } = null!;
        // ReSharper disable once NullableWarningSuppressionIsUsed
        
       // [Inject] public IJSRuntime Js { get; set; } = null!;

        /// <summary>
        /// Add [JSInvokable] above your override
        /// </summary>
        public virtual Task InteropEventCallback(string id, CallerName name, EventType type, Dictionary<string, string>? classList , JavascriptEvent? e )
            => Task.CompletedTask;
        
        /// <summary>
        /// Add [JSInvokable] above your override
        /// </summary>
        public virtual Task InteropEventCallback(string id, CallerName name, EventType type)
            => Task.CompletedTask;
        
        /// <summary>
        /// Add [JSInvokable] above your override
        /// </summary>
        public virtual Task InteropResizeComplete(int width)
            => Task.CompletedTask;

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string DataId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Top, Bottom, Left, Right Margins
        /// </summary>
        [Parameter]
        public Margins Margin { get; set; }

        /// <summary>
        /// Bottom Margin
        /// </summary>
        [Parameter]
        public Margins MarginBottom { get; set; }

        /// <summary>
        /// End/Right Margin
        /// </summary>
        [Parameter]
        public Margins MarginEnd { get; set; }

        /// <summary>
        /// Left and Right Margins
        /// </summary>
        [Parameter]
        public Margins MarginLeftAndRight { get; set; }

        /// <summary>
        /// Start/Left Margin
        /// </summary>
        [Parameter]
        public Margins MarginStart { get; set; }

        /// <summary>
        /// Top Margin
        /// </summary>
        [Parameter]
        public Margins MarginTop { get; set; }

        /// <summary>
        /// Top and Bottom Margins
        /// </summary>
        [Parameter]
        public Margins MarginTopAndBottom { get; set; }

        /// <summary>
        /// Top, Bottom, Left, Right Padding
        /// </summary>
        [Parameter]
        public Padding Padding { get; set; }

        /// <summary>
        /// Bottom Padding
        /// </summary>
        [Parameter]
        public Padding PaddingBottom { get; set; }

        /// <summary>
        /// End/Right Padding
        /// </summary>
        [Parameter]
        public Padding PaddingEnd { get; set; }

        /// <summary>
        /// Left and Right Padding
        /// </summary>
        [Parameter]
        public Padding PaddingLeftAndRight { get; set; }

        /// <summary>
        /// Start/Left Padding
        /// </summary>
        [Parameter]
        public Padding PaddingStart { get; set; }

        /// <summary>
        /// Top Padding
        /// </summary>
        [Parameter]
        public Padding PaddingTop { get; set; }

        /// <summary>
        /// Top and Bottom Padding
        /// </summary>
        [Parameter]
        public Padding PaddingTopAndBottom { get; set; }

        /// <summary>
        /// Position Helper
        /// </summary>
        [Parameter]
        public Position Position { get; set; } = Position.Default;

        protected bool EventsSet;

        public string? LayoutClass => new CssBuilder()
            .AddClass($"p-{Padding.ToIndex()}", Padding != Padding.Default)
            .AddClass($"pt-{PaddingTop.ToIndex()}", PaddingTop != Padding.Default)
            .AddClass($"pb-{PaddingBottom.ToIndex()}", PaddingBottom != Padding.Default)
            .AddClass($"ps-{PaddingStart.ToIndex()}", PaddingStart != Padding.Default)
            .AddClass($"pe-{PaddingEnd.ToIndex()}", PaddingEnd != Padding.Default)
            .AddClass($"px-{PaddingLeftAndRight.ToIndex()}", PaddingLeftAndRight != Padding.Default)
            .AddClass($"py-{PaddingTopAndBottom.ToIndex()}", PaddingTopAndBottom != Padding.Default)
            .AddClass($"m-{Margin.ToIndex()}", Margin != Margins.Default)
            .AddClass($"mt-{MarginTop.ToIndex()}", MarginTop != Margins.Default)
            .AddClass($"mb-{MarginBottom.ToIndex()}", MarginBottom != Margins.Default)
            .AddClass($"ms-{MarginStart.ToIndex()}", MarginStart != Margins.Default)
            .AddClass($"me-{MarginEnd.ToIndex()}", MarginEnd != Margins.Default)
            .AddClass($"mx-{MarginLeftAndRight.ToIndex()}", MarginLeftAndRight != Margins.Default)
            .AddClass($"my-{MarginTopAndBottom.ToIndex()}", MarginTopAndBottom != Margins.Default)
            .AddClass($"position-{Position.NameToLower()}", Position != Position.Default)
            .Build().ToNullString();
    }
}