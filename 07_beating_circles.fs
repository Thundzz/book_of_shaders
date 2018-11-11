// Author @patriciogv - 2015
// http://patriciogonzalezvivo.com

#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

vec3 circle(vec2 origin, float radius, vec2 st)
{
        float smoothness = 0.001;
        float pct = 1.-smoothstep(radius - smoothness, radius + smoothness,distance(st,origin));
        return vec3(pct);
}


void main(){
    vec2 st = gl_FragCoord.xy/u_resolution;
    float pct = 0.0;
    
    vec3 color = vec3(0.855,0.427,0.443) * circle(vec2(0.3, 0.8), 0.10*abs(sin(2.*u_time))+0.05, st);
    
    color += vec3(0.855,0.427,0.443) * circle(vec2(0.290,0.200), 0.10*abs(sin(1.648*u_time))+0.05, st);
    
    color += vec3(0.466,0.730,0.855) * circle(vec2(0.440,0.290), 0.10*abs(sin(2.*u_time))+0.05, st);
    
    color += vec3(0.846,0.855,0.258) * circle(vec2(0.650,0.670), 0.10*abs(sin(2.*u_time))+0.05, st);

    gl_FragColor = vec4( color, 1.0 );
}
