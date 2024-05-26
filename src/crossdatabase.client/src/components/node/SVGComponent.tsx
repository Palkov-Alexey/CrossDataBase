import React, { Component } from 'react';
import PropTypes, { ReactNodeLike } from 'prop-types'

type SVGComponentProps = {
  height: string;
  width: string;
  ref: string;
  children: ReactNodeLike[];
}

class SVGComponent extends Component<SVGComponentProps> {
  render() {
    return <svg style={{position:'absolute', zIndex:9000}} {...this.props} ref="svg">{this.props.children}</svg>;
  }
}

export default SVGComponent