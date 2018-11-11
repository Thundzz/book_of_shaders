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

    vec3 color = circle(vec2(0.5), 0.25, st);

    gl_FragColor = vec4( color, 1.0 );
}
