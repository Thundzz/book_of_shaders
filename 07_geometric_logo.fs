#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359
#define TWO_PI 6.28318530718

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;


float ngon_field(int nbSides, vec2 origin, vec2 st)
{
  // Angle and radius from the current pixel
  st = st - origin;
  float a = atan(st.x,st.y)+PI;
  float r = TWO_PI/float(nbSides);

  // Shaping function that modulate the distance
  return cos(floor(.5+a/r)*r-a)*length(st);
}
// Reference to
// http://thndl.com/square-shaped-shaders.html

void main(){
  vec2 st = gl_FragCoord.xy/u_resolution.xy;
  st.x *= u_resolution.x/u_resolution.y;
  vec3 color = vec3(0.0);
  float d = 0.0;

  // Remap the space to -1. to 1.
  st = st *2.-1.;
  
  // Number of sides of your shape
  float d1 = ngon_field(4, vec2(-0.190,0.230), st );
  float d2 = ngon_field(4, vec2(0.180,-0.180), st );
    
  d = min(d1, d2);

  color = vec3(0.411,0.570,0.514)* vec3(1.0-smoothstep(.4,.41,d));
  //color = vec3(d);

  gl_FragColor = vec4(color,1.0);
}
