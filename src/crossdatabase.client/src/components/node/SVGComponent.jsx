import { Component } from 'react';
import PropTypes from 'prop-types'

class SVGComponent extends Component {
  render() {
    return <svg style={{position:'absolute', zIndex:9000}} {...this.props} ref="svg">{this.props.children}</svg>;
  }
}

SVGComponent.propTypes = {
  children: PropTypes.node
}

export default SVGComponent