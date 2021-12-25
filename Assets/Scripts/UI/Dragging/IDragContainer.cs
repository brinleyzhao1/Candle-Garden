using UI.Dragging;

namespace UI
{
  /// <summary>
  /// Acts both as a source and destination for dragging. If we are dragging
  /// between two containers then it is possible to swap items.
  /// </summary>
  /// <typeparam name="T">The category that represents the item being dragged.</typeparam>
  public interface IDragContainer<T> : IDragDestination<T>, IDragSource<T> where T : class
  {
  }
}
