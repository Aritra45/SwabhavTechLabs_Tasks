import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHover]',
  standalone: false
})
export class HoverDirective {

  constructor( private element:ElementRef, private renderer:Renderer2) { }

  @HostListener('mouseenter') onmouseenter(){
    this.renderer.addClass(this.element.nativeElement, 'hover')
  }
  @HostListener('mouseleave') onmouseleave(){
    this.renderer.removeClass(this.element.nativeElement, 'hover')
  }
}
