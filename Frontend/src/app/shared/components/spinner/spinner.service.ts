import { Injectable, ComponentFactoryResolver, ApplicationRef, Injector, EmbeddedViewRef, ComponentRef } from '@angular/core';
import { SpinnerComponent } from './spinner.component';


@Injectable({
  providedIn: 'root'
})

export class SpinnerService {
  private spinnerRef!: ComponentRef<SpinnerComponent> | null;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private appRef: ApplicationRef,
    private injector: Injector
  ) { }

  public show(): void {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(SpinnerComponent)
      .create(this.injector);
    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;
    document.body.appendChild(domElem);
    this.spinnerRef = componentRef;
  }

  public hide(): void {
    if (this.spinnerRef !== null) {
      this.appRef.detachView(this.spinnerRef.hostView);
      this.spinnerRef.destroy();
      this.spinnerRef = null;
    }
  }
}
