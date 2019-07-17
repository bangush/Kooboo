import { createDiv } from "@/dom/element";

export function createHeader(title: string, parent: HTMLElement) {
  var el = createDiv();
  el.classList.add("kb_web_editor_modal_header");
  el.innerText = title;
  el.draggable = true;
  let temp: { x: number; y: number };
  el.ondragstart = (e: DragEvent) => {
    let rect = parent.getBoundingClientRect();
    temp = { x: e.x - rect.left, y: e.y - rect.top };
  };

  el.ondrag = e => {
    if (e.x == 0 || e.y == 0) return;
    parent.style.marginLeft = e.x - temp.x + "px";
    parent.style.marginTop = e.y - temp.y + "px";
  };
  return el;
}
