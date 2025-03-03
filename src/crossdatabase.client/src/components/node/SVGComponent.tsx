import { Component, RefObject, createRef } from 'react';

type SVGComponentProps = {
  height: string;
  width: string;
  ref: RefObject<SVGSVGElement>;
  children: any[];
}

class SVGComponent extends Component<SVGComponentProps> {
  ref: RefObject<SVGSVGElement>

  constructor(props: SVGComponentProps) {
    super(props)

    this.ref = createRef()
  }

  render() {
    let { children } = this.props;

    return <svg style={{ position: 'absolute', zIndex: 1 }} {...this.props} ref={this.ref}>{children}</svg>;
  }
}

export default SVGComponent