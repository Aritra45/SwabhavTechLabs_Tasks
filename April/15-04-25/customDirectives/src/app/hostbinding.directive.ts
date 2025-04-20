import { Directive, ElementRef, HostBinding, HostListener, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHostbinding]',
  standalone: false
})
export class HostbindingDirective {

  constructor( private element:ElementRef, private renderer:Renderer2) { }
 @Input()
  bgColorHost? :any
  @Input() defaultColor? : any
    @HostBinding('style.backgroundColor') background = this.defaultColor

    @HostListener('mouseenter') onmouseenter(){
      this.background = this.bgColorHost
    }
    @HostListener('mouseleave') onmouseleave(){
      this.background = this.defaultColor
    }
}
