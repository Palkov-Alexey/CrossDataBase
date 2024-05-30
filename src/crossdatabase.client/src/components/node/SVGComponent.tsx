import { Component, RefObject, createRef } from 'react';
import { ReactNodeLike } from 'prop-types'

type SVGComponentProps = {
  height: string;
  width: string;
  ref: string;
  children: ReactNodeLike[];
}

class SVGComponent extends Component<SVGComponentProps> {
  ref: RefObject<any>

  constructor(props: SVGComponentProps) {
    super(props)

    this.ref = createRef()
  }

  render() {
    return <svg style={{ position: 'absolute', zIndex: 9000 }} {...this.props} ref={this.ref}>{this.props.children}</svg>;
  }
}

export default SVGComponent